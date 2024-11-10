using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using model;


namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<castumeres> GetAllCastumeres();

        [OperationContract]
        List<gauides> GetAllGauides();

        [OperationContract]
        bool CheckCastumerIfExist(string id);

         [OperationContract]
        bool CheckcityIfExist(string ncity);

        [OperationContract]
        bool Checkchugifexcist(string namech);

        [OperationContract]
        castumeres GetCustById(string id);

       [OperationContract]
      int AddCastumer(castumeres s);

        [OperationContract]
        void AddManui(menuyim n);

        [OperationContract]
        List<Chugim> GetAllChugim();

        [OperationContract]
        List<typ_chugim> GetAllTyp_Chugims();

        [OperationContract]
        List<rishum_to_lesson> GetLessonsInWeekForCustomer(int ccodeManuy);

        [OperationContract]
        menuyim GetManuy(int codeManuy);

        [OperationContract]
        List<city> GetAllcity();

        [OperationContract]
        List<category> GetAllcategory();

        [OperationContract]
        List<typ_menuyim_price_> GetAllTypmanui();

        [OperationContract]

        List<menuyim> GetManuyToCust(castumeres id);

        [OperationContract]
        int GetCodtotypmanuy();

        [OperationContract]
        int GetCodtomenuyim();

        [OperationContract]
        int GetCodtotypchugim();

        [OperationContract]
        int GetCodtocity();

        [OperationContract]
        int Addtypchug(typ_chugim t);

        [OperationContract]
        int Addcity(city c);

        [OperationContract]
        int Addtypmanui(typ_menuyim_price_ t);

        [OperationContract]
        int Addlesson(Chugim c);

        [OperationContract]
        int GetNumLessonfree(int codeManuy);

        [OperationContract]
        int delate(castumeres c);

        [OperationContract]
        int delatguaid(gauides g);

        [OperationContract]
       int delateciey(city c);

        [OperationContract]
        int delatetypchug(typ_chugim t);

        [OperationContract]
        int Addlesontomanui(rishum_to_lesson r);

        [OperationContract]
        List<rishum_to_lesson> GetAlrishum();

        [OperationContract]
        int Addgauid(gauides g);

        [OperationContract]
        int GetCodtogauid();
    }
}
