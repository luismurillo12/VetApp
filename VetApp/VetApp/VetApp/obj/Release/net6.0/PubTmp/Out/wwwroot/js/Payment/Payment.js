document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('botonAgregar').addEventListener('click', function () {
        var insumosInput = document.getElementById('insumosInput');
        var cantidadInput = document.getElementById('cantidadInput');
        var cantidad = parseFloat(cantidadInput.value);
        var cantidadDescuentoInput = document.getElementById('productoDInput');
        var cantidadDescuento = parseFloat(cantidadDescuentoInput.value) || 0;
        var descuentoInputVal = parseFloat(document.getElementById('descuentoInput').value) / 100 || 0;
        var descuentoInput = document.getElementById('descuentoInput');
        var descuento = parseFloat(descuentoInput.value);
        var cantidad = parseFloat(cantidadInput.value) || 0;
        var productoDInput = document.getElementById('productoDInput');
        var productosConDescuento = parseFloat(productoDInput.value) || 0;
        var descuentoInput = document.getElementById('descuentoInput');
        var descuento = parseFloat(descuentoInput.value) || 0;
        var productoDInput = document.getElementById('productoDInput');
        var productosConDescuento = parseFloat(productoDInput.value) || 0;


        ////Validaciones
        if (insumosInput.value === "") {
            $('#alertaModal').modal('show');
            return;
        }

        if (isNaN(cantidad) || cantidad < 1) {
            $('#cantidadAlertaModal').modal('show');
            return;
        }


        if (descuentoInput.value && (isNaN(descuento) || descuento < 1 || descuento > 100)) {
            $('#descuentoInvalidoModal').modal('show');
            return;
        }


        if (productoDInput.value && (isNaN(productosConDescuento) || productosConDescuento < 1 || productosConDescuento > cantidad)) {
            $('#productosDescuentoInvalidoModal').modal('show');
            return;
        }


        if (descuento > 0 && (!productoDInput.value || isNaN(productosConDescuento) || productosConDescuento <= 0)) {
            $('#descuentoSinProductosModal').modal('show');
            return;
        }



        //////Lógica de agregar filas a la tabla
        var servicio = insumosInput.options[insumosInput.selectedIndex].text;
        var instrucciones = document.getElementById('instruccionesInput').value;
        var precioUnitario = parseFloat(insumosInput.options[insumosInput.selectedIndex].getAttribute('data-precio')) || 0;
        var precioConDescuento = descuentoInputVal > 0 ? (precioUnitario - (precioUnitario * descuentoInputVal)) : precioUnitario;
        var precioTotalDescuento = precioConDescuento * Math.min(cantidad, cantidadDescuento);
        var precioTotalSinDescuento = precioUnitario * (cantidad - cantidadDescuento);
        var precioTotal = precioTotalDescuento + precioTotalSinDescuento;

        var tabla = document.getElementById('miTabla').getElementsByTagName('tbody')[0];
        var nuevaFila = tabla.insertRow();
        nuevaFila.insertCell(0).innerHTML = servicio;
        nuevaFila.insertCell(1).innerHTML = instrucciones;
        nuevaFila.insertCell(2).innerHTML = cantidad;
        nuevaFila.insertCell(3).innerHTML = precioTotal.toFixed(2);

        // Crear botón de eliminar y añadir a la nueva fila
        var btnEliminar = document.createElement('button');
        btnEliminar.textContent = 'Eliminar';
        btnEliminar.style.color = 'white';
        btnEliminar.style.color = 'white';
        btnEliminar.style.backgroundColor = 'red';
        btnEliminar.style.border = '1px solid red';
        btnEliminar.onclick = function () {
            this.closest('tr').remove();
            actualizarTotal();
        };
        var celdaEliminar = nuevaFila.insertCell();
        celdaEliminar.appendChild(btnEliminar);


        actualizarTotal();

        // Limpiar los campos de entrada
        document.getElementById('cantidadInput').value = '';
        document.getElementById('instruccionesInput').value = '';
        document.getElementById('descuentoInput').value = '';
        document.getElementById('productoDInput').value = '';
        $('#insumosInput').val(null).trigger('change');
    });

    document.getElementById('ivaPInput').addEventListener('input', actualizarTotal);
    document.getElementById('ivaSInput').addEventListener('input', actualizarTotal);




    var tipofacturaInput = document.getElementById('tipofacturaInput');
    var tipopagoInput = document.getElementById('tipopagoInput');

    function actualizarVistas() {
        var divCancelaCon = document.getElementById('divCancelaCon');
        var divCredito = document.getElementById('divCredito');
        var divVuelto = document.getElementById('divVuelto');
        var divReferencia = document.getElementById('divReferencia');

        // Ocultar todos los divs primero
        divCancelaCon.style.display = 'none';
        divCredito.style.display = 'none';
        divVuelto.style.display = 'none';
        divReferencia.style.display = 'none';

        // Condiciones para mostrar los divs
        if (tipofacturaInput.value === '1') {
            if (tipopagoInput.value === '1') {
                divCancelaCon.style.display = 'block';
                divVuelto.style.display = 'block';
            } else if (tipopagoInput.value != '1') {
                divReferencia.style.display = 'block';
            }
        } else if (tipofacturaInput.value === '2') {
            if (tipopagoInput.value === '1') {
                divCancelaCon.style.display = 'block';
                divCredito.style.display = 'block';
            } else if (tipopagoInput.value != '1') {
                divCancelaCon.style.display = 'block';
                divCredito.style.display = 'block';
                divReferencia.style.display = 'block';
            }
        }
    }

    // Agregar el evento de cambio a ambos selectores
    //tipofacturaInput.addEventListener('change', actualizarVistas);
    //tipopagoInput.addEventListener('change', actualizarVistas);

    // Inicializar la vista
    /*actualizarVistas();*/




    //Lógica mostrar total y actualizar con IVAS
    function actualizarTotal() {
        var total = 0;
        var tabla = document.getElementById('miTabla').getElementsByTagName('tbody')[0];
        var filas = tabla.getElementsByTagName('tr');

        for (var i = 0; i < filas.length; i++) {
            var precio = parseFloat(filas[i].cells[3].innerHTML) || 0;
            total += precio;
        }

        var ivaPInput = parseFloat(document.getElementById('ivaPInput').value) || 0;
        var totalIVAProducto = total * (ivaPInput / 100);
        var ivaSInput = parseFloat(document.getElementById('ivaSInput').value) || 0;
        var totalIVAServicio = total * (ivaSInput / 100);
        var totalFInput = total + totalIVAProducto + totalIVAServicio;

        document.getElementById('totalpagar').value = total.toFixed(2);
        document.getElementById('totalFInput').value = totalFInput.toFixed(2);

        // Actualizar preciototalInput con el mismo valor que totalFInput
        document.getElementById('preciototalInput').value = totalFInput.toFixed(2);
    }


    // Función para calcular y actualizar el vuelto
    function calcularVuelto() {

        var total = parseFloat(preciototalInput.value) || 0;
        var cancelado = parseFloat(canceladoInput.value) || 0;

        if ($("#divVuelto").is(":visible")) {
            var vuelto = cancelado - total;
            vueltoInput.value = vuelto > 0 ? vuelto.toFixed(2) : '0.00';
        } else {
            var vuelto = total - cancelado;
            if (cancelado > total) {
                $("#btnProcesar").prop("disabled", true);
                $('#MensajeValidacion').text('Monto ingresado superior al total a cancelar.');
                console.log('');
            } else {
                $("#btnProcesar").prop("disabled", false);
            }
            // Asegurarse de que el vuelto no sea negativo
            balanceInput.value = vuelto > 0 ? vuelto.toFixed(2) : '0.00';
        }
        
    }

    // Eventos para actualizar el vuelto cuando los valores cambien
    preciototalInput.addEventListener('input', calcularVuelto);
    canceladoInput.addEventListener('input', calcularVuelto);

    // Inicializar el valor del vuelto al cargar la página
    calcularVuelto();


    //Validacion para la referencia
    //document.getElementById('btnProcesar').addEventListener('click', function () {

    //});

});


let minDate = new Date();
let minDateConversion = minDate.getFullYear() + '-' + validatePaymentMonth(minDate) + '-' + validatePaymentDay(minDate);
$("#fechaInput").attr('min', minDateConversion);

function getDetailsTable() {
    var datos = [];
    $('#miTabla tbody tr').each(function () {
        var fila = {
            nameDetail: $(this).find('td').eq(0).text(),
            descriptionDetail: $(this).find('td').eq(1).text(),
            amountDetail: parseInt($(this).find('td').eq(2).text()),
            costDetail: parseInt($(this).find('td').eq(3).text())
        };
        datos.push(fila);
    });
    return datos;
}

function CreateInvoices() {
    let validate = validateInputPayments();

    if (validate) {
        var detailInvoice = getDetailsTable();

        var numReference = $('#referencia').val();
        var dateInvoices = $('#fechaInput').val();
        var totalCancel = parseInt($('#preciototalInput').val());
        var totalCanceled = parseInt($('#canceladoInput').val());
        var idPaymentType = $('#tipopagoInput').val();
        var idClient = $('#clienteInput').val();
        var invoiceType = $('#tipofacturaInput').val();
        let idCreditClient = $('#creditClientSelect').val();

        if (idCreditClient == null) {
            var credit = {
                dateCredit: dateInvoices,
                totalBalance: totalCancel,
                totalCredit: totalCancel
            }
        } else {
            var credit = {
                idCredit: idCreditClient,
                dateCredit: dateInvoices,
                totalBalance: totalCanceled,
                totalCredit: totalCancel
            }
        }

        $.ajax({
            type: "POST",
            url: "../Payment/CreateInvoices",
            dataType: "json",
            data: {
                "numReference": numReference,
                "dateInvoices": dateInvoices,
                "totalCancel": totalCancel,
                "totalCanceled": totalCanceled,
                "idPaymentType": idPaymentType,
                "idClient": idClient,
                "invoiceType": invoiceType,
                "detailInvoices": detailInvoice,
                "credit": credit
            },
            success: function (res) {

                if (res > 0) {

                    Swal.fire({
                        title: '',
                        icon: 'success',
                        text: 'Factura registrada correctamente.',
                        confirmButtonText: 'Ok'
                    }).then((result) => {
                        if (result['isConfirmed']) {
                            location.reload();
                        }
                    })

                    return;
                }
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Revisa que todos los datos solicitados se han ingresado.',
                });

            }
        });
    }
}

$('#clienteInput').on('change', function () {
    let tipoFactura = $('#tipofacturaInput').val();
    if (tipoFactura === '2') {
        GetCreditsByIdClient(this.value);
    }
});

$('#tipopagoInput').on('change', function () {

    let paymentType = parseInt(this.value);

    if (paymentType > 1) {
        $("#divReferencia").css("display", "block");
    } else {
        $("#divReferencia").css("display", "none");
    }
});


function GetCreditsByIdClient(idClient) {

    if (idClient === '0') {
        $("#divCreditClient").css("display", "none");
        $("#divCredito").css("display", "none");
        $("#divVuelto").css("display", "block");
        return;
    }

    $.ajax({
        type: "GET",
        url: "../Payment/GetCreditsByIdClient?idClient=" + idClient,
        dataType: "json",
        success: function (res) {

            $("#divCreditClient").css("display", "none");
            $("#divCredito").css("display", "none");
            $("#divVuelto").css("display", "block");

            if (res.length > 0) {

                Object.keys(res).forEach(function (key) {

                    let optionText = '#' + res[key].idCredit;
                    let optionValue = res[key].idCredit;

                    parseFloat($('#preciototalInput').val(res[key].totalBalance));

                    $('#creditClientSelect').append(new Option(optionText, optionValue));
                });

                $("#divCreditClient").css("display", "block");
                $("#divCredito").css("display", "block");
                $("#divVuelto").css("display", "none");
            }


        }
    });
}

function validateAmount() {

    let totalCancel = parseFloat($('#preciofinalInput').val());
    let totalCanceled = parseFloat($('#canceladoInput').val());

    let result = totalCanceled - totalCancel;

    if (result > 0) {
        parseFloat($('#vueltoInput').val(result));
    } else {
        parseFloat($('#vueltoInput').val(0));
    }

}

function validatePaymentMonth(date) {

    let mes = date.getMonth()

    if (mes + 1 === 1) {
        mes = '01';
        return mes;
    }

    if (mes <= 9) {
        mes = mes + 1;
        mes = '0' + mes;
        return mes;
    }

    return mes + 1;
}

function validatePaymentDay(date) {

    let day = date.getDate();

    if (day <= 9) {

        day = '0' + day;

        return day;
    }

    return day;
}

function validateInputPayments() {

    var numReference = $('#referencia').val();
    var dateInvoices = $('#fechaInput').val();
    var totalCancel = $('#preciototalInput').val();
    var totalCanceled = $('#canceladoInput').val();
    var idPaymentType = $('#tipopagoInput').val();
    var idClient = $('#clienteInput').val();
    var invoiceType = $('#tipofacturaInput').val();
    let idCreditClient = $('#creditClientSelect').val();
    let totalFInput = $('#totalFInput').val();

    if (totalFInput.trim().length > 0 && idCreditClient != null) {

        $('#MensajeValidacion').text('El cliente no puede sacar un cr\u00E9dito hasta que cancele el que tiene pendiente.');
        $('#referenciaFaltanteModal').modal('show');

        return false;
    }

    if (invoiceType === '0') {
        $('#MensajeValidacion').text('Seleccione el tipo de factura.');
        $('#referenciaFaltanteModal').modal('show');
        return false;
    }

    if (idClient === '0' && invoiceType === '2') {
        $('#MensajeValidacion').text('Debe de seleccionar un cliente cuando el tipo de factura es cr\u00E9dito.');
        $('#referenciaFaltanteModal').modal('show');
        return false;
    }

    if (dateInvoices.trim().length === 0) {
        $('#MensajeValidacion').text('Debe de ingresar una fecha.');
        $('#referenciaFaltanteModal').modal('show');
        return false;
    }

    if (idPaymentType === '0') {
        $('#MensajeValidacion').text('Seleccione el tipo de pago.');
        $('#referenciaFaltanteModal').modal('show');
        return false;
    }

    if (totalCancel.trim().length === 0) {
        $('#MensajeValidacion').text('No existe un monto a cancelar.');
        $('#referenciaFaltanteModal').modal('show');
        return false;
    }

    if (totalCanceled.trim().length === 0) {
        $('#MensajeValidacion').text('Debe de ingresar el monto a cancelar.');
        $('#referenciaFaltanteModal').modal('show');
        return false;
    }

    if (numReference.trim().length === 0 && idPaymentType != '1') {
        $('#MensajeValidacion').text('Debe de ingresar un n\u00FAmero de referencia.');
        $('#referenciaFaltanteModal').modal('show');
        return false;
    }

    return true;
}