function ShowDetailsInvoicesModal(idInvoice) {
    $.ajax({
        type: "GET",
        url: "../Reportes/GetDetailByIdInvoices?idInvoice=" + idInvoice,
        dataType: "json",
        success: function (res) {
            CreateDetailsInvoicesTbl(res);

            $('#detailsInvoicesModal').modal('show');

        }
    });
}

function CreateDetailsInvoicesTbl(list) {

    let dtDetails = document.getElementById("dtDetailsInvoice"); 
    let idInvoices = 0;

    $("#dtDetailsInvoice").find("tr:gt(0)").remove();

    for (var i = 0; i < list.length; i++) {
        var row = dtDetails.insertRow();
        var cell1 = row.insertCell();
        var cell2 = row.insertCell();
        var cell3 = row.insertCell();
        var cell4 = row.insertCell();
        var cell5 = row.insertCell();
        cell1.innerHTML = list[i]["idDetail"];
        cell2.innerHTML = list[i]["nameDetail"];
        cell3.innerHTML = list[i]["descriptionDetail"];
        cell4.innerHTML = list[i]["amountDetail"];
        cell5.innerHTML = list[i]["costDetail"];
        idInvoices = parseInt(list[i]["idInvoices"]);
    }

    $('#detailsInvoicesTitleModal').text('Detalles Factura #'+idInvoices);
}


function ShowInvoicesCreditsModal(idClient) {
    $.ajax({
        type: "GET",
        url: "../Reportes/GetDepositsCreditsByIdClient?idClient=" + idClient,
        dataType: "json",
        success: function (res) {

            CreateInvoicesCreditsTbl(res);

            $('#invoicesCreditsModal').modal('show');

        }
    });
}

function CreateInvoicesCreditsTbl(list) {

    let dtDetails = document.getElementById("dtInvoicesCredits");
    let idCredits = 0

    $("#dtInvoicesCredits").find("tr:gt(0)").remove();
    for (var i = 0; i < list.length; i++) {
        var row = dtDetails.insertRow();
        var cell1 = row.insertCell();
        var cell2 = row.insertCell();
        var cell3 = row.insertCell();
        var cell4 = row.insertCell();
        var cell5 = row.insertCell();
        var cell6 = row.insertCell();
        var cell7 = row.insertCell();
        var cell8 = row.insertCell();

        cell1.innerHTML = list[i]["idInvoices"];
        cell2.innerHTML = list[i]["numReference"];
        cell3.innerHTML = list[i]["dateInvoices"];
        cell4.innerHTML = list[i]["totalCancel"];
        cell5.innerHTML = list[i]["totalCanceled"];
        cell6.innerHTML = list[i]["paymentName"];
        cell7.innerHTML = list[i]["clientName"];

        let typeInvoice = parseInt(list[i]["idCredit"]);
        idCredits = typeInvoice;

        if (typeInvoice > 0) {
            cell8.innerHTML = "Cr\u00E9dito";
        } else {
            cell8.innerHTML = "Contado";
        }
    }

    $('#invoicesCreditsModalTitle').text('Facturas Cr\u00E9dito #' + idCredits);
}