using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DataAccessGame;
using DataAccessGame.Models;
using ServiceModels;

namespace WCFServerDoNotStepOnLine
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public bool GetConnect()
        {
            return true;
        }

        public SPlayer AddPlayer(SPlayer newPlayer)
        {
            using (var cli = new DBGContext())
            {
                Player NP = new Player()
                {
                    DateRegistration = DateTime.Now,
                    DateLastAction = DateTime.Now,
                    DeviceId = newPlayer.DeviceId,
                    GoogleId = newPlayer.GoogleId,
                    Name = newPlayer.Name,
                    Password = GeneratePassword(),
                    Ip = GetIpClient(),
                };
                cli.Players.Add(NP);
                PlayerInfoStatistic NPIS = new PlayerInfoStatistic() 
                {
                    AllStep = 0,
                    Coins = 0,
                    Distance = 0f,
                    Donat = 0,
                    LinkPlayer = NP,
                    MaxCombo = 0,
                    PerfectSteps = 0,
                    PlayedGames = 0,
                    QuestComplete = 0
                };
                cli.PlayerInfoStatistics.Add(NPIS);
                cli.SaveChanges();
                newPlayer.PlayerId = NP.PlayerId;
                newPlayer.Password = NP.Password;
                return newPlayer;
            }
        }

        string GeneratePassword()
        {
            Random rndGen = new Random();
            string rc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] newPass = new char[6];
            for (int i = 0; i < 6; i++)
            {
                newPass[i] = rc[rndGen.Next(rc.Length)];
            }
            return new string(newPass);
        }

        string GetIpClient()
        {
            // ЭТО ВСЕ ЕЩЁ НАДО ПРОТЕСТИРОВАТЬ!
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpoint.Address;
        }

        public SPlayer CheckPlayer(SPlayer newPlayer)
        {
            using (var cli = new DBGContext())
            {
                var CP = cli.Players.FirstOrDefault(x => x.PlayerId == newPlayer.PlayerId);
                CP.Ip = GetIpClient();
            //    CP.DateLastAction = DateTime.Now;
                cli.SaveChanges();
                // нужно сделать проблемные варианты...
                return newPlayer;
            }/**/
        }

        public void UpdateStatistic(SPlayerInfoStatistic sPISC)
        {
            try
            {
                using (var cli = new DBGContext())
                {
                    var pisc = cli.PlayerInfoStatistics.Include(x => x.LinkPlayer).FirstOrDefault(x => x.LinkPlayer.PlayerId == sPISC.LinkPlayer.PlayerId);
                    pisc.AllStep = sPISC.AllStep;
                    pisc.Coins = sPISC.Coins;
                    pisc.Distance = sPISC.Distance;
                    pisc.Donat = sPISC.Donat;
                    pisc.MaxCombo = sPISC.MaxCombo;
                    pisc.PerfectSteps = sPISC.PerfectSteps;
                    pisc.PlayedGames = sPISC.PlayedGames;
                    pisc.QuestComplete = sPISC.QuestComplete;
                    cli.SaveChanges();
                }
            }
            catch { }
        }

        public void UpdateAchievement(SAchievement sAchievement)
        {
            try
            {
                using (var cli = new DBGContext())
                {
                    Achievement upAch;
                    upAch = cli.Achievements.Include(x => x.LinkPlayer).FirstOrDefault(x => x.LinkPlayer.PlayerId == sAchievement.LinkPlayer.PlayerId && x.NameAchievement == sAchievement.NameAchievement);
                    if (upAch == null)
                    {
                        upAch = new Achievement()
                        {
                            LinkPlayer = cli.Players.FirstOrDefault(x => x.PlayerId == sAchievement.LinkPlayer.PlayerId),
                            NameAchievement = sAchievement.NameAchievement,
                            NumberRewards = sAchievement.NumberRewards,
                        };
                        cli.Achievements.Add(upAch);
                    }
                    else
                    {
                        upAch.NumberRewards = sAchievement.NumberRewards;
                    }
                    cli.SaveChanges();
                }
            }
            catch { }
        }

        public void UpdateRecord(SRecord sRecord)
        {
            try
            {
                using (var cli = new DBGContext())
                {
                    Record UR;
                    UR = cli.Records.Include(x => x.LinkPlayer).FirstOrDefault(x => x.LinkPlayer.PlayerId == sRecord.LinkPlayer.PlayerId && x.Mode == sRecord.Mode);
                    if (UR == null)
                    {
                        UR = new Record() 
                        {
                            LinkPlayer = cli.Players.FirstOrDefault(x => x.PlayerId == sRecord.LinkPlayer.PlayerId),
                            Mode = sRecord.Mode
                        };
                        cli.Records.Add(UR);
                    }
                    if (UR.Score < sRecord.Score)
                        UR.Score = sRecord.Score;
                    if (UR.MaxSpeed < sRecord.MaxSpeed)
                        UR.MaxSpeed = sRecord.MaxSpeed;
                    if (UR.MaxTime < sRecord.MaxTime)
                        UR.MaxTime = sRecord.MaxTime;

                    cli.SaveChanges();
                }
            }
            catch { }
        }

        public List<SRecord> GetTopRecords(string param, int mode)
        {
            try
            {
                using (var cli = new DBGContext())
                {
                    switch (param)
                    {
                        case "Score":
                            return cli.Records.Include(x => x.LinkPlayer).Where(x => x.Mode == mode).OrderByDescending(x => x.Score).Take(10).Select(x => new SRecord() 
                            {
                                Score = x.Score,
                                MaxSpeed = x.MaxSpeed,
                                MaxTime = x.MaxTime,
                                Steps = x.Steps,
                                Mode = mode,
                                LinkPlayer = new SPlayer() 
                                {
                                    PlayerId = x.LinkPlayer.PlayerId,
                                    Name = x.LinkPlayer.Name,
                                }
                            }).ToList();
                        case "Steps":
                            return cli.Records.Include(x => x.LinkPlayer).Where(x => x.Mode == mode).OrderByDescending(x => x.Steps).Take(10).Select(x => new SRecord()
                            {
                                Score = x.Score,
                                MaxSpeed = x.MaxSpeed,
                                MaxTime = x.MaxTime,
                                Steps = x.Steps,
                                Mode = mode,
                                LinkPlayer = new SPlayer()
                                {
                                    PlayerId = x.LinkPlayer.PlayerId,
                                    Name = x.LinkPlayer.Name,
                                }
                            }).ToList();
                        default:
                            break;
                    }
                    return new List<SRecord>();
                } 
            }
            catch(Exception ex)
            {           
                return new List<SRecord>();
            }
        }

        public SQuestResponse GenerateQuest(SPlayer whoRequesting)
        {
            SQuestResponse questResponse = new SQuestResponse() { SCanGenerate = false };
            try
            {
                using (var cli = new DBGContext())
                {
                    var checkPlayer = cli.Players.FirstOrDefault(x => x.PlayerId == whoRequesting.PlayerId);
                    if (checkPlayer.DateLastAction.Subtract(checkPlayer.DateLastAction.TimeOfDay) < DateTime.Now.Subtract(DateTime.Now.TimeOfDay))
                    {
                        checkPlayer.DateLastAction = DateTime.Now;
                        cli.SaveChanges();
                        questResponse.SCanGenerate = true;
                        questResponse.SleftTime = DateTime.Now.AddDays(1).Subtract(DateTime.Now.TimeOfDay).Subtract(DateTime.Today);
                        return questResponse;
                    }
                }
            }
            catch
            {
            }
            return questResponse;
        }
    }
}