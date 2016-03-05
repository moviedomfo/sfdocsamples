



var httpHost = Getrootpath('');
var siteViewModel = null;
$(function () {
  
    //$('[data-toggle=offcanvas]').click(function () {
    //    $('.row-offcanvas').toggleClass('active');
    //});
    //$('.numeric').numeric();
    //$('.leftContent li a').click(function (e) {
    //    var $this = $(this);
    //    if (!$this.hasClass('active')) {
    //        $this.addClass('active');
    //    }
    //    e.preventDefault();
    //});

  
    //        var guid = $.urlParam('uniqueGuid');

    //        if (guid != null)
    //            $('.instance').each(function () {
    //                $(this).attr('href', $(this).attr('href') + guid);
    //  
    //var datepicker = $.fn.datepicker.noConflict(); // return $.fn.datepicker to previously assigned value
    //$.fn.bootstrapDP = datepicker;                 // give $().bootstrapDP the bootstrap-datepicker functionality
    //$('.datepicker').bootstrapDP({
    //    todayBtn: "linked",
    //    calendarWeeks: true,
    //    autoclose: true,
    //    todayHighlight: true,
    //    language: "es",
    //    format: "dd/mm/yyyy"
    //});

  


    //Globalize.culture("es-AR", "es-AR");
  
});







function ServiceFailed(xhr, status, p3, p4) {
    var errMsg = status + " " + p3;
    //var errObj = JSON.parse(xhr.responseText);
    errMsg = errMsg + "\n" + xhr.responseText;

    ShowAlertMessage(errMsg, "", "info", "", function () {
       
    });

    Showloading(false);
}


function Getrootpath(href) {

    //return 'http://ws2008/SecPortal/';
    var url = document.location.protocol + '//' + document.location.host;
    var root = document.location + '/';
    var aux = '';
    var temp = new Array();
    temp = root.split('/');
    aux = temp[2].toString();

    if (aux.indexOf('localhost:', 0) == -1) {
        if (temp.length == 6)
            url = url + '/' + temp[3] + href;
        else
            url = url + '/' + href;
    }
    else {
        url = url + href;
    }

    return url;
}

function Showloading(show) {
    if (show) {
        //$('.loading').html('<img class="ajaxloader" src="@Url.Content("~/img/ajax-loader.gif")"/>');
        $('.ajaxloader').show();
        $('#alert-text-view').hide('slow');
    }
    else {
        $('.ajaxloader').hide();
        //$('.loading').empty();
    }
}



///messagetype error,warning,info,help
function ShowAlertMessage(text, title, mesagetype, smalltitle, OnSuccessCallback) {

    var src_img = '/content/img/';
    if (mesagetype == 'error') {
        src_img = src_img + 'indicator_error38.png';
    }
    if (mesagetype == 'warning') {
        src_img = src_img + 'warning38.png';
    }
    if (mesagetype == 'info') {
        src_img = src_img + 'info_blue48.png';
    }
    if (mesagetype == 'help') {
        src_img = src_img + 'help_grey48.png';
    }

    if (!smalltitle)
        smalltitle = '';
    if (!title)
        title = 'Sistema de gestion de clubs';
    var _html = '<div class="media"> <a href="#" class="pull-left">';
    _html += '<img  id="message-alert-img" src="' + src_img + '" class="media-object img-rounded" alt=""></a>';

    _html += '<div class="media-body">';
    _html += '<h4 id = "message-title" class="media-heading">' + title + '<small><i>' + smalltitle + '</i></small></h4>';
    _html += '<br/>';
    _html += '<p>' + text + '</p>';
    _html += '</div> </div>';



    bootbox.alert(_html, OnSuccessCallback);
}


function OnSuccess(ajaxContext) {
    $('#aler-text-view').hide();
    if (ajaxContext.Result && ajaxContext.Result == 'ERROR_FUNCTIONAL') {
        OnFailure(ajaxContext);
    }
    if (ajaxContext.Result && ajaxContext.Result == 'ERROR') {
        ShowAlertMessage(ajaxContext.Message, 'Error en el servidor', 'error','');
    }
    if (ajaxContext.Result && ajaxContext.Result == 'OK') {

        ShowAlertMessage(ajaxContext.Message, "", "info", "", function () {
            if (ajaxContext.RedirectTo) {
                window.location.href = ajaxContext.RedirectTo;
            }
        }
       );
    }
   
}



function OnFailure(ajaxContext) {
    var alertText = $('#alert-text-view');
    alertText.show('slow');

    if (ajaxContext.responseText)
        alertText.find('.error-text').text(ajaxContext.responseText);
    else
        alertText.find('.error-text').text(ajaxContext.Message);
}


function OnFailureId(ajaxContext,alertId) {
    var alertText = $('#' + alertId);
    alertText.show('slow');

    if (ajaxContext.responseText)
        alertText.find('.error-text').text(ajaxContext.responseText);
    else
        alertText.find('.error-text').text(ajaxContext.Message);
}

function RefreshPage() {
    $.ajax({
        url: "",
        context: document.body,
        success: function (s, x) {
            $(this).html(s);
        }
    });
}

function SetPanel_CRUD(controlId,isEdit)
{
    if (isEdit) {
        $('#' + controlId).addClass('panel-success');
        $('#' + controlId).removeClass('panel-warning');
    }
    else {
        $('#' + controlId).addClass('panel-warning');
        $('#' + controlId).removeClass('panel-success');
       
    }
}


function RefrechGrid(controller) {
    $.ajax(
     {
         url: httpHost + "/" + controller + "/RetriveGrid/",
        type: "POST",
    dataType: 'html',
    contentType: "application/json;charset=utf-8",
    data: null,
    success: function (result) {
        $('#grid').html(result);
    },
    error: ServiceFailed
});
}


