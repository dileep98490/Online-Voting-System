/// <reference path="jquery-1.4.4-vsdoc.js" />
/// <reference path="jquery-ui.js" />
$(document).ready(function () {
    $(":input[data-autocomplete]").each(function () {
        $(this).autocomplete({ source: $(this).attr("data-autocomplete") })
    })



})

