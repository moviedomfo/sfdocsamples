import { IAPIRequest } from './common.model';
import { AddressBE, PersonBE } from './persons.model';



export class StockBE {

    public  QuotationRequestId: number;

    public StockId: number;
     
     public TypeId: number;
     //public TypeText: string;
     public StockAlertPersent: number;
     
     public Description: string;
     public Cost:number;
     public Stock:number;
     public StockMax:number;
     public LastAccessTime: Date;
     public LastAccessUserId: string;
     public UserName: string;
  
    public StockPersent:number;
}



export class QuotationRequestBE {

    public QuotationRequestId: number;
    public UserId: string;
    public UserName: string;
    public StatusId: number;
    public StatusText: string;
    public Conditions: string;
    public Observations: string;
    public UpdateDate?: Date;
    public QuotationRequestDetails: QuotationRequestDetailBE[];
    public OrderProviderAssignaments: OrderProviderAssignamentBE[];

}

export class OrderProviderAssignamentBE{
    public QuotationRequestId: number;
    public ProviderId: number;
    public ProviderName: string;
    public UpdateDate: Date;
    public Email : string;

    public Person : PersonBE;
}

export class QuotationRequestDetailBE {

    public  QuotationRequestId: number;
    public  StockId: number;
     public Count: number;
     public Description: string;
     public Order: number;
     

}

export class ProviderStockOfferQuotationReqBE {
    public QuotationRequestId: number;
    public providerId: number;
    public StockId: number;
    public count: number;
    public cost: number;

    public updateDate: Date;
    public userId: string;
    public userName: string;

}



export class StockCreateReq extends  IAPIRequest{
    
    public Stock: StockBE;
   
   
}

export class StockUpdateReq extends  IAPIRequest{
    
    public Stock: StockBE;
}

export class StockRemoveReq extends  IAPIRequest{
    
    public StockId: number;
}


export class OrderCreateReq extends  IAPIRequest{
    
    
    public Observations: string;
    public Conditions: string;
    public QuotationRequestDetails : QuotationRequestDetailBE[];
}


export class OrderUpdateReq extends  IAPIRequest{
    
    public QuotationRequestId: number;
    public Observations: string;
    public Conditions: string;
    public StatusId: number;
    public QuotationRequestDetails : QuotationRequestDetailBE[];

}
export class QuotationRequestDeleteReq extends  IAPIRequest{
    public id: number;
}
export class assignProviderToOrderServiceReq extends  IAPIRequest{
    
    public QuotationRequestId: number;
    public providers: number[];
}

export class updateProviderToOrderServiceReq extends  IAPIRequest{
    
    public QuotationRequestId: number;
    public providers: number[];
}

export class sendEmailToProvidersServiceReq extends  IAPIRequest{
    
    public QuotationRequestId: number;
    public sendToAdmin: number;
    public providers: number[];
    
}

export class removeProviderToOrderServiceReq extends  IAPIRequest{
    
    public QuotationRequestId: number;
    public ProviderId: number;
}


export class providerStockOfferQuotationReqBE {
    
    public QuotationRequestId: number;
    public ProviderId: number;
    public StockId: number;
    public Count: number;
    public Cost: number;
    //public bestOffer:boolean;

    public ProviderName :string
    public OrderDetailDescription:string;

    public UpdateDate:Date;
    public UserName:string;

    public UserId:string;
    public BestOffer: boolean;
    public ProviderStockName:string;
    
}
             

export class ProviderStockOfferQuotationReqFullView extends  IAPIRequest{
    
    public QuotationRequestId: number;
    public ProviderId: number;
    public StockId: number;
    public Count: number;
    public Cost: number;

    public OrderedCount: number;
    public Description: string;
    public ProviderName: string;
    public BestOffer:boolean;
    public ProviderStockName :string;
}


export class PedidoBE {

    public Id: number;
    public QuotationRequestId: number;
    public ProviderId: number;
    
    public CreatedDate: Date;
    public Details : PedidoDetailBE[];

    public Person : PedidosPersonDataBE;
    
    public QuotationRequestObservations :string;
    public StatusName :string;
    public Status :number;
}


export class PedidosPersonDataBE
{
    public  ProviderName : string;
    public  IdentityCardNumber : string;
    public  Lastname : string;
    public  Name : string;
    public  Phone1 : string;
    public  Phone2 : string;
    public  Email : string;
    public  MailLabel : string;
    public  Phone1label : string;
    public  Phone2label : string;


}
 /**
  * detalle del pedido
  */
export class PedidoDetailBE {
    //puede ser null si es que no esta almacenado
    public Id:number;
    public StockId: number;
    
    /**
    * nombre que le da el porveedor
    */
    public ProviderStockName :string;

   
    /**
    * nombre que tenemos almacenado en la bd
    */
    public StockName:string;
    
    /**
    *  precio que tiene el porveedor por unidad
    */
    public OfferCost: number;

    
    /**
    * cantidad a pedir
    */
    public Count: number;
  
     
    /**
    * Si == false no vino de la BD
    */
    public Checked:boolean;

    public Description:string;
    
}

export class createProviderStockOfferQuotationReqReq extends  IAPIRequest{
    public QuotationRequestId: number;
    public ProviderStockOfferQuotationReqList:providerStockOfferQuotationReqBE[];
}

export class updateProviderStockOfferQuotationReqReq extends  IAPIRequest{
    public QuotationRequestId: number;
    public ProviderStockOfferQuotationReqList:providerStockOfferQuotationReqBE;
}