<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Stastic.aspx.cs" Inherits="SurveySystem.Stastic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../code/highcharts.js"></script>
    <script src="../../code/modules/exporting.js"></script>
    <script src="../../code/modules/export-data.js"></script>
    <script src="../../code/modules/accessibility.js"></script>
    <figure class="highcharts-figure">
        <p class="highcharts-description"></p>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div id='container<%# Eval("QDID") %>'></div>
                <script type="text/javascript">
                    Highcharts.chart('container<%# Eval("QDID") %>', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: '<%# Eval("QDID") %>.<%# Eval("Question") %>'
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        accessibility: {
                            point: {
                                valueSuffix: '%'
                            }
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,
                                    format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                                }
                            }
                        },
                        series: [{
                            name: 'Brands',
                            colorByPoint: true,
                            data: [<%= OptionData()%>]
                        }]
                    });
                </script>
            </ItemTemplate>
        </asp:Repeater>        
    </figure>
</asp:Content>
