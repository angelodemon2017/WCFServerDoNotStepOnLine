using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiceModels;

namespace WCFServerDoNotStepOnLine
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool GetConnect();

        [OperationContract]
        SPlayer AddPlayer(SPlayer newPlayer);

        [OperationContract]
        SPlayer CheckPlayer(SPlayer newPlayer);

        [OperationContract]
        void UpdateStatistic(SPlayerInfoStatistic sPISC);

        [OperationContract]
        void UpdateAchievement(SAchievement sAchievement);

        [OperationContract]
        void UpdateRecord(SRecord sRecord);

        [OperationContract]
        List<SRecord> GetTopRecords(string param, int mode);

        [OperationContract]
        SQuestResponse GenerateQuest(SPlayer whoRequesting);
    }
}
