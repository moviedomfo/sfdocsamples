<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WCFWebSite._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


<script type="text/javascript">

    var varType;
    var varUrl;
    var varData;
    var varContentType;
    var varDataType;
    var varProcessData;

    function CallService() {
        $.ajax({
            type: varType, //GET or POST or PUT or DELETE verb
            url: varUrl, // Location of the service
            data: varData, //Data sent to server
            contentType: varContentType, // content type sent to server
            dataType: varDataType, //Expected data format from server
            processdata: varProcessData, //True or False
            success: function (msg) {//On Successfull service call
                ServiceSucceeded(msg);
            },
            error: ServiceFailed// When Service call fails
        });
    }

    function Test_WebGet_Json() {
       
        varType = "GET";
        varUrl = "service/CoreSecurityAspnet.svc/Test_WebGet_Json?value=" + $('#txtInput').val();
        varContentType = "application/json; charset=utf-8";
        varDataType = "json"; varProcessData = false; CallService();
    }

    function Test_POST_XML() {
        varType = "POST";
        varUrl = "service/CoreSecurityAspnet.svc/Test_POST_XML";
        varData = '{"value": "' + $('#txtInput').val() + '"}';
        varContentType = "application/json; charset=utf-8";
        varDataType = "xml";
        varProcessData = true;
        CallService();
    }


    function Test_POST_Json() {
        varType = "POST";
        varUrl = "service/CoreSecurityAspnet.svc/Test_POST_Json";
        varData = '{"value": "' + $('#txtInput').val() + '"}';
        varContentType = "application/json; charset=utf-8";
        varDataType = "json";
        varProcessData = true;
        CallService();
    }

    function Test_GET_REST_Json() {
        varType = "GET";
        varUrl = "service/CoreSecurityAspnet.svc/Test_GET_REST_Json/" + $('#txtInput').val();
        varContentType = "application/json; charset=utf-8";
        varDataType = "json";
        varProcessData = false;
        CallService();
    }

    function ServiceSucceeded(result) {
        var resultObject = null;
        if (varDataType == "xml") {

            $(result).find("Test_POST_XMLResult").children().each(function () {
                alert($(this).text());
            });

            return;
        }

        if (varDataType == "json") {
            if (varType == "GET")
            { resultObject = result; }
            else {

                resultObject = result.Test_POST_JsonResult;
                //                    if (resultObject == null) {
                //                        //WCF Service with multiple output paramaetrs //Button 4
                //                        resultObject = result.GetProvinceAndBrowserResult.ProvinceInfo;
            }
            alert(resultObject);
            return;
        }
    }

    function ServiceFailed(result) {
        alert('Service call failed: ' + result.status + '' + result.statusText);
        varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;
    }
</script>
    <h2>
        Test calling WCF from ajax jquery 
    </h2>
    <br />
    <br />
    <p>
       Input value to call the service
    </p>
 
    <input class="frm_inputtext"  id="txtInput" type="text"  style="font-size:14px; width:200px;height:2em;background-color:#FFFFE6;"/>
       <br />
    <br />
 
    
    <table width="100%">
            <tr class="frm_row" style="margin: 8px">
                <td style="width: 150px; text-align: left;">
                    Call WCF WebGet
                </td>
                <td style="width: 350px;">
                    <input id="Submit1" type="submit" value="Call service" onclick="Test_WebGet_Json();return false;" />
                </td>
            </tr>
     <tr class="frm_row" style="margin: 8px">
                <td style="width: 150px; text-align: left;">
                    Call WCF POST/REST XML
                </td>
                <td style="width: 350px;">
                    <input id="Submit2" type="submit" value="Call service" onclick="Test_POST_XML();return false;" />
                </td>
            </tr>
  
            <tr class="frm_row" style="margin: 8px">
                <td style="width: 150px; text-align: left;">
                        Call WCF POST/REST JSON
                </td>
                <td style="width: 350px;">
                    <input id="Submit3" type="submit" value="Call service" onclick="Test_POST_Json();return false;" />
                </td>
            </tr>
       </table>


       <table width="100%">
         <tr class="frm_row" style="margin: 8px">
                <td style="width: 150px; text-align: left;">
                        Call WCF GET/REST JSON
                </td>
                <td style="width: 350px;">
                    <input id="Submit4" type="submit" value="Call service" onclick="Test_GET_Json();return false;" />
                </td>
            </tr>
       </table>
</asp:Content>
