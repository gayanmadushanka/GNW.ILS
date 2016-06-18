namespace Pervation.Presentation.DashBoard
{
    public enum DashBoardLinkEnum
    {
        NODATA,
        //Sales Analysis
        SAN,

        //Cost Analysis
        CAN,

        //Location Wise Sales Analysis
        LWS,

        //Company Wise Sale Analysis
        CWS,

        //Customer Outstanding
        CUO,

        //Top 10 Fast Moving Items
        FMI,

        //Top 10 Slow Moving Items
        SMI,

        //Top 10 Customers
        TCU,

        //Company Wise Collection
        CWC,

        //Salesman Wise Sales
        SWS,

        //Route Wise Sales
        RWS,

        //Company Wise Sales Return
        CWSR,

        //Company Wise Stock Valuation
        CWSV
    }

    public enum GridTypeEnum
    {
        GdChart1,
        GdChart2,
        GdChart3,
        GdChart4
    }

    public enum ChartTypeEnum
    {
        NODATA,
        PI,
        LINEAR,
        BAR
    }

    public enum DataLoadTypeEnum
    {
        Daily,
        Weekly,
        Monthly,
        Yearly,
        NoData
    }
}