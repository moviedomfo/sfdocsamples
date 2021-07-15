

namespace celam.api.common.BE
{

    public enum CommonValuesEnum
    {
        TodosComboBoxValue = -1000,
        VariosComboBoxValue = -2000,
        SeleccioneUnaOpcion = -3000,
        Ninguno = -4000,
        /// <summary>
        /// Esta opcion es usada para seleccion de Mutuales .- Caso Sin mutual particular
        /// </summary>
        Particular = -5000
    }

    public enum MonthsShortName_ES
    {
        ENE = 1,
        FEB = 2,
        MAR = 3,
        ABR = 4,
        MAY = 5,
        JUN = 6,
        JUL = 7,
        AGO = 8,
        SET = 9,
        OCT = 10,
        NOV = 11,
        DIC = 12

    }
    public enum MonthsNames_ES
    {
        Enero = 1,
        Febrero = 2,
        Marzo = 3, Abril = 4, Mayo = 5, Junio = 6, Julio = 7, Agosto = 8,
        Septiembre = 9,
        Octubre = 10,
        Noviembre = 11,
        Diciembre = 12

    }


    public enum ParamTypeEnum
    {
        Clasificacion1 = 1000,
        Clasificacion2 = 5000,
        PersonStatus = 100,
        MemberStatus = 150
    }

    /// <summary>
    /// Estado socio
    /// </summary>
    public enum MemberStatus
    {
        Activo,
        Inactivo,
        Desvinculado,

    }

    public enum PedidoStatus
    {
        Creado = 541,
        Autorizado = 542,
        Rechazado = 543,
        Enviado = 544,
        Recivido = 545,
        
    }
    /// <summary>
    /// Estado persona
    /// </summary>
    public enum PersonStatus
    {
        Activo = 501,
        Inactivo = 502,
        Desvinculado = 503,
        PendienteAuth = 304

    }

    /// <summary>
    /// ParentId 520
    /// </summary>
    public enum QuotationRequestStatus

    {
        Created = 521,
        Apporved = 522,
        SendedToProviders = 523,
        Closed = 524
    }
}

