/// <reference path="../jquery-1.5.1-vsdoc.js" />

$(function () {
    var geocoder;
    var markersArray = [];
    var map;
    var mapHeight;
    var markerBusqueda;

    function initialize() {

        $("#tabs").tabs();
        $('#divMap').height(function (index, height) {
            mapHeight = size(this);
            $('#divListado').height(mapHeight - 30);
            return mapHeight;
        });
        $(window).resize(function () {
            $('#divMap').height(function (index, height) {
                mapHeight = size(this);
                $('#divListado').height(mapHeight - 30);
                return mapHeight;
            });
        });
        var myOptions = {
            zoom: 12,
            center: new google.maps.LatLng(-33.4365, -70.6235),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        geocoder = new google.maps.Geocoder();
        map = new google.maps.Map(document.getElementById('divMap'), myOptions);
        google.maps.event.addListener(map, 'dragend', function () {
            buscarEscuelas();
        });

        google.maps.event.addListener(map, 'zoom_changed', function () {
            buscarEscuelas();
        });
    }

    function size(container) {
        return window.innerHeight - $(container).offset().top;
    }

    function buscarEscuelas() {
        var northEast = map.getBounds().getNorthEast();
        var southWest = map.getBounds().getSouthWest();
        $("#spanCargando").show();
        TAEM.IAPIService.ListLugares(
                { Latitud: northEast.lat(), Longitud: northEast.lng() },
                { Latitud: southWest.lat(), Longitud: southWest.lng() },
                map.getZoom(),
                { QueDonar: $('#txtQueDonar').val() },
                function (result) {
                    $("#spanCargando").hide();
                    $("#spanNumeroEscuelas").text(result.Items.length);
                    $.each(markersArray, function (index, val) {
                        val.setMap(null);
                    });
                    markersArray.length = 0;
                    $("#divListado").empty();
                    $.each(result.Items, function (index, val) {
                        var marker = new google.maps.Marker({
                            icon: '/Content/images/escuela.png',
                            position: new google.maps.LatLng(val.Posicion.Latitud, val.Posicion.Longitud),
                            map: map,
                            title: val.Nombre
                        });
                        markersArray.push(marker);

                        var div = document.createElement("div");
                        $(div).attr("class", "item");
                        $(div).html(val.Nombre);
                        $(div).click(function () {
                            openForm(val);
                        });

                        $("#divListado").append(div);


                        google.maps.event.addListener(marker, 'click', function () {
                            openForm(val);
                        });
                    });

                },
            function (err) {
                alert(err);
            }
            );
    }

    function openForm(val) {
        $("#dialog").load("/Formulario/FichaColegio/" + val.ID + "?" + (Math.round(Math.random() * 1000000000)).toString());
        $("#dialog").dialog({ title: val.Nombre,
            modal: true,
            minHeight: 600,
            minWidth: 800
        });
    }

    function buscarDirecciones(address) {
        geocoder.geocode({ 'address': address, 'region': 'CL', 'language': 'es' }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {

                map.setCenter(results[0].geometry.location);
                map.setZoom(13);
                if (markerBusqueda == null) {
                    markerBusqueda = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location,
                        zIndex: 1000
                    });
                } else {
                    markerBusqueda.setPosition(results[0].geometry.location);
                }

                buscarEscuelas();
            } else {
                alert("No se pudo encontrar la dirección " + status);
            }
        });
    }

    $(document).ready(function () {
        initialize();
        buscarDirecciones($("#txtDireccion").val());
        
    });

    $("#btnBuscar").click(function () {
        buscarDirecciones($("#txtDireccion").val());
    });

    $("#txtDireccion").keypress(function (event) {
        if (event.which == 13) {
            event.preventDefault();
            buscarDirecciones($("#txtDireccion").val());
        }
    });
});

