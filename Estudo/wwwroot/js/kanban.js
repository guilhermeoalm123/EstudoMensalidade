﻿$(function () {
    var kanbanCol = $('.panel-body');
    //kanbanCol.css('max-height', (window.innerHeight - 150) + 'px');

    //var kanbanColCount = parseInt(kanbanCol.length);
    /*$('.container-fluid').css('min-width', (kanbanColCount * 350) + 'px');*/

    draggableInit();

    $('.panel-heading').click(function () {
        var $panelBody = $(this).parent().children('.panel-body');
        $panelBody.slideToggle();
    });
});

function draggableInit() {
    var sourceId;

    $('[draggable=true]').bind('dragstart', function (event) {
        sourceId = $(this).parent().attr('id');
        event.originalEvent.dataTransfer.setData("text/plain", event.target.getAttribute('id'));
    });

    $('.panel-body').bind('dragover', function (event) {
        event.preventDefault();
    });

    $('.panel-body').bind('drop', function (event) {
        var children = $(this).children();
        var targetId = children.attr('id');

        if (sourceId != targetId) {
            var elementId = event.originalEvent.dataTransfer.getData("text/plain");

            
            if (targetId == "DOING" && targetId != "undefined") {
                window.location = window.origin + "\\Home\\CadastrarPagamento\\" + elementId + ";" + $("#MensalidadeCodigo option:selected").val();
            } 
                if (targetId == "TODO" && targetId != "undefined") {
                window.location = window.origin + "\\Home\\ExcluirPagamento\\" + elementId + ";" + $("#MensalidadeCodigo option:selected").val();
            }
            


            $('#processing-modal').modal('toggle'); //before post


            // Post data 
            setTimeout(function () {
                var element = document.getElementById(elementId);               
                children.prepend(element);
                $('#processing-modal').modal('toggle'); // after post
            }, 1000);

        }

        event.preventDefault();
    });
}
