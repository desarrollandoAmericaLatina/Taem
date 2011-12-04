

$(function () {

    $("#Proyectotabs").tabs();



    $("button", ".btns").button();
    //$("a", ".demo").click(function () { return false; });


    $('#btnIngresarUsuario').click(function () {


                $('#dialog').dialog({ resizable: false,
                    draggable: false,
                    modal: true,
                    title: 'Autenticando'
                });

                var txtValor = $('#RDBIngresar').val();

                if (txtValor != "") {
                    location.href = '/Proyecto/Crear?rbd=' + $('#RDBIngresar').val();
                }
    });

    //    $('#btnIngresar').click(function () {

    //        console.log('entree');

    //        $('#dialog').dialog({ resizable: false,
    //            draggable: false,
    //            modal: true,
    //            title: 'Autenticando'
    //        });

    //        var txtValor = $('#RDBIngresar').val();

    //        if (txtValor != "") {
    //            localtion.href = '/Proyecto/Crear/' + $('#RDBIngresar').val();
    //        }




    //    });



    $('#btnNecesidad').bind("click", function () {


        $("#dialog").html($('#dvNecesidadDet').html());

        $("#dialog").dialog({
            minHeight: 300,
            minWidth: 480,
            resizable: false,
            draggable: false,
            modal: true,
            title: 'Nueva necesidad',
            /*
            load: function (event, ui) {
            console.log('entre');
                

            },*/
            buttons: {
                Ok: function () {

                    if ($('#frmNuevaNecesidadDet').valid()) {
                        //console.log('ok necesidad');
                    } else {
                        //console.log('fail necesidad');
                    }
                    //$(this).dialog("close");
                },
                Cerrar: function () {
                    $(this).dialog("close");
                }
            }
        });

    });


    $('#frmNuevaNecesidad').validate(

    {
        errorPlacement: function (error, element) {
            $("#spanErrorFijo").html($('<br/>')).html(error);
        }
    }

    );

    $('#Nombre').rules("add", {
        required: true,
        maxlength: 100,
        messages: {
            required: "Por favor Ingrese un <b>nombre</b> de proyecto.",
            maxlength: "El campo descripción no puede superar los 100 caracteres."
        }
    });


    $('#Descripcion').rules("add", {
        required: true,
        maxlength: 2000,
        messages: {
            required: "Por favor Ingrese una <b>descripcion</b> de proyecto.",
            maxlength: "El campo descripción no puede superar los 2000 caracteres."
        }
    });

    $('#Fechadeseable').rules("add", {
        required: true,
        messages: {
            required: "Por favor Ingrese una <b>fecha deseable</b>."
        }
    });


    $('#Fechadeseable').rules("add", {
        required: true,
        messages: {
            required: "Por favor Ingrese una <b>fecha deseable</b>."
        }
    });


    $('#frmNuevaNecesidadDet').validate(
                   {
                       errorPlacement: function (error, element) {
                           $("#spanErrorModel").html($('<br/>')).html(error);
                       }
                   }
                );



    $('#NombreNecesidad').rules("add", {
        required: true,
        maxlength: 100,
        messages: {
            required: "Por favor Ingrese un <b>nombre necesidad</b> de proyecto.",
            maxlength: "El campo descripción no puede superar los 100 caracteres."
        }
    });

    $('#DescripcionNecesidad').rules("add", {
        required: true,
        maxlength: 2000,
        messages: {
            required: "Por favor Ingrese una <b>descripción necesidad</b> de proyecto.",
            maxlength: "El campo descripción no puede superar los 2000 caracteres."
        }
    });

    $('#btnGuardar').click(function () {
        if ($('#frmNuevaNecesidad').valid()) {
            console.log('valido');
        } else {
            console.log('invalido');
        }
    });



    //    /*GRILLA*/
    //    $("#listProyectos").jqGrid({
    //        url: 'mid/ot.ashx?fnc=getListadoDiarioGrid',
    //        datatype: 'json',
    //        mtype: 'GET',
    //        jsonReader: {
    //            root: "rows",
    //            page: "page",
    //            total: "total",
    //            records: "records",
    //            cell: "cell",
    //            id: "id"
    //        },
    //        colNames: ['V', 'Nombre', 'Descripcion', 'PersonaResponsable', 'FechaIngreso', 'Necesidades'],
    //        colModel: [
    //                      { name: 'Ver', index: 'Ver', width: 23, sortable: false, align: 'center' },
    //                      { name: 'IDProyecto', index: 'Id_Ot', width: 50, align: 'right' },
    //                      { name: 'Nombre', index: 'Id_Ot', width: 50, align: 'right' },
    //                      { name: 'Descripcion', index: 'Tipo_Prioridad_Descrip', width: 80, align: 'center' },
    //                      { name: 'PersonaResponsable', index: 'Tipo_Mantenimiento_Descrip', width: 90, align: 'left' },
    //                      { name: 'FechaIngreso', index: 'Sistema_Ingenieria', width: 120, align: 'left' },
    //                      { name: 'Necesidades', index: 'Especialidad', width: 100, align: 'left' }                 
    //        ],
    //        height: 450,
    //        shrinkToFit: false,
    //        autowidth: true,
    //        pager: '#pager',
    //        sortname: 'Tipo_Prioridad_Descrip',
    //        sortorder: 'asc',
    //        caption: 'Listado Diario',
    //        ondblClickRow: function (rowId) {
    //            $tabs.tabs("add", "DetalleOTListadoDiarioLider.aspx?idTab=" + tab_counter + "&idOt=" + rowId, "OT Nro:" + rowId);
    //            tab_counter++;
    //        }

    //    });




});
