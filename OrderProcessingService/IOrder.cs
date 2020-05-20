using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OrderProcessingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    [ServiceContract]
    public interface IOrder
    {

       
        [OperationContract]
         String getCustomer(String cid);

        [OperationContract]
         int Purchase(String cid, List<String> od);

        [OperationContract]
         List<String> getOrderDetails(String oid);

        [OperationContract]
         List<String> getCustomerOrders(String id);

        [OperationContract]
         List<String> getProductIds();

        [OperationContract]
         String getProductDetail(String id);

        // TODO: Add your service operations here
    }


}
