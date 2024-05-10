$(document).on("click", "#btnAddService", function () {

    $("#serviceNameModal").prop("readonly", false);
    $("#serviceCostModal").prop("readonly", false);


    $("#serviceNameModal").val('');
    $("#serviceCostModal").val('');
    

    $('#servicesModal').modal('show');
});

function SaveChangesServiceModal() {
    let idService = $("#idServiceModal").val();
    let validateInput = validateServiceInputs();

    if (validateInput) {
        if (idService.trim().length === 0) {
            CreateService();
        } else {
            UpdateService();
        }
    }
}

function CreateService() {
    let serviceName = $("#serviceNameModal").val();
    let serviceCost = parseFloat($("#serviceCostModal").val());

    $.ajax({
        type: "POST",
        url: "../Service/CreateService",
        dataType: "json",
        data: {
            "serviceName": serviceName,
            "serviceCost": serviceCost
        },
        success: function (res) {
            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Servicio registrado correctamente.',
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
                text: 'Lo sentimos ha ocurrido un error.',
            });
        }
    });
}

function OpenUpdateServiceModal(idService) {
    $.ajax({
        type: "GET",
        url: "../Service/GetService?idService=" + idService,
        dataType: "json",
        success: function (res) {
            $("#serviceNameModal").prop("readonly", false);
            $("#serviceCostModal").prop("readonly", false);           


            $("#idServiceModal").val(res.idService);
            $("#serviceNameModal").val(res.serviceName);
            $("#serviceCostModal").val(res.serviceCost);

            $('#servicesModal').modal('show');
        }
    
    });
}

function UpdateService() {
    let idService = $("#idServiceModal").val();
    let serviceName = $("#serviceNameModal").val();
    let serviceCost = parseFloat($("#serviceCostModal").val());

    $.ajax({
        type: "PUT",
        url: "../Service/UpdateService",
        dataType: "json",
        data: {
            "IdService": idService,
            "serviceName": serviceName,
            "serviceCost": serviceCost
        },
        success: function (res) {
            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Servicio actualizado correctamente.',
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
                text: 'Lo sentimos ha ocurrido un error.',
            });
        }
    });
}

let idTempService = 0;

function OpenDeleteConfirmServiceModal(idService) {
    idTempService = idService;
    $('#deleteServiceModal').modal('show');
}

function DeleteService() {
    $.ajax({
        type: "DELETE",
        url: "../Service/DeleteService?idService=" + idTempService,
        dataType: "json",
        success: function (res) {
            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Servicio eliminado correctamente.',
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
                text: 'El servicio no puede ser eliminado, ya que esta siendo utilizado en otras funcionalidades del sistema.',
            });
        }
    });
}

function validateServiceInputs() {
    let serviceName = $("#serviceNameModal").val();
    let serviceCost = $("#serviceCostModal").val();

    let serviceNameMessage = $("#serviceNameModalMessage");
    let serviceCostMessage = $("#serviceCostModalMessage");

    serviceNameMessage.text("");
    serviceCostMessage.text("");

    if (serviceName.trim().length === 0) {
        serviceNameMessage.text("El nombre del servicio no puede estar vac\u00EDo.");
        return false;
    }
    if (serviceCost.trim().length === 0 || isNaN(serviceCost)) {
        serviceCostMessage.text("El costo del servicio debe ser un n�mero vac\u00EDo.");
        return false;
    }

    return true;
}
