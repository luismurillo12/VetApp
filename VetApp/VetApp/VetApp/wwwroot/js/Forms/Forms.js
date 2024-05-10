let idClienteModalMessage = $("#idClienteModalMessage");
let idPetModalModalMessage = $("#idPetModalModalMessage");
let idDoctorModalMessage = $("#idDoctorModalMessage");
let arrivalModalMessage = $("#arrivalModalMessage");
let attentionModalMessage = $("#attentionModalMessage");
let idProductModalMessage = $("#idProductModalMessage");
let idServiceModalMessage = $("#idServiceModalMessage");
let statusPModalMessage = $("#statusPModalMessage");
let motiveModalMessage = $("#motiveModalMessage");

$(document).ready(function () {
    $("#motiveModal").attr('maxlength', '50');
});

$(document).on("click", "#btnAddForms", function () {

    $("#arrivalModal").prop("disabled", false);
    $('#idClienteModal').prop('disabled', false);
    $('#idPetModal').prop('disabled', false);
    $('#idDoctorModal').prop('disabled', false);

    $("#idMedicalRecordModal").val('');
    $("#idClienteModal").val(0);
    $('#idPetModal').empty().append(' <option value="0">Seleccione una Mascota</option>');
    $("#idDoctorModal").val(0);
    $("#arrivalModal").val('');
    $("#attentionModal").val('');
    $("#idProduct").val(0);
    $("#idService").val(0);
    $("#statusP").val('');
    $("#motiveModal").val('')

    idClienteModalMessage.text("");
    idPetModalModalMessage.text("");
    idDoctorModalMessage.text("");
    arrivalModalMessage.text("");
    attentionModalMessage.text("");
    idProductModalMessage.text("");
    idServiceModalMessage.text("");
    statusPModalMessage.text("");
    motiveModalMessage.text("");

    $('#formsModal').modal('show');

});

function SavaChangesFormsModal() {

    let idMedicalRecord = $("#idMedicalRecordModal").val();

    let validateInput = validateInputs();


    if (validateInput) {

        if (idMedicalRecord.trim().length === 0) {
            CreateForms();
        } else {
            UpdateForms();
        }

    }


}

function CreateForms() {
    let idDoctorModal = $("#idDoctorModal").val();
    let idPetModal = $("#idPetModal").val();
    let idClienteModal = $("#idClienteModal").val();
    let motiveModal = $("#motiveModal").val();
    let arrivalModal = $("#arrivalModal").val();
    let attentionModal = $("#attentionModal").val();
    let idProduct = $("#idProduct").val();
    let idService = $("#idService").val();
    let statusP = $("#statusP").val();

    if (statusP === '1') {
        statusP = true;
    } else {
        statusP = false;
    }

    $.ajax({
        type: "POST",
        url: "../Forms/CreateForms",
        dataType: "json",
        data: {
            "idUser": idDoctorModal,
            "idPet": idPetModal,
            "idClient": idClienteModal,
            "motive": motiveModal,
            "arrival": arrivalModal,
            "attention": attentionModal,
            "idProduct": idProduct,
            "idService": idService,
            "statusP": statusP
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Registrado correctamente.',
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
                title: 'Erorr',
                text: 'Lo sentimos ha ocurrido un error.',
            });

        }
    });

}

function OpenUpdateFormsModal(idMedicalRecord) {


    $.ajax({
        type: "GET",
        url: "../Forms/GetForms?idMedicalRecord=" + idMedicalRecord,
        dataType: "json",
        success: function (res) {

            $("#arrivalModal").prop("disabled", true);

            $("#idMedicalRecordModal").val(res.idMedicalRecord);
            $("#idDoctorModal").val(res.idDoctor);

            $('#idPetModal').empty();
            $('#idPetModal').append(new Option(res.petName, res.idPet));

            $("#idClienteModal").val(res.idClient);
            $("#motiveModal").val(res.motive);

            $('#idClienteModal').prop('disabled', true);
            $('#idPetModal').prop('disabled', true);
            $('#idDoctorModal').prop('disabled', true);


            let arrival = new Date(res.arrival);
            let arrivalHour = validateFormHour(arrival) + ':' + validateFormMinutes(arrival);

            let attention = new Date(res.attention);
            let attentionHour = validateFormHour(attention) + ':' + validateFormMinutes(attention);

            $("#arrivalModal").val(arrivalHour);
            $("#attentionModal").val(attentionHour);

            $("#idProduct").val(res.idProduct);
            $("#idService").val(res.idService);

            if (res.statusP) {
                $("#statusP").val(1);
            } else {
                $("#statusP").val(0);
            }

            $('#formsModal').modal('show');



        }
    });
}

function UpdateForms() {

    let idMedicalRecord = $("#idMedicalRecordModal").val();
    let idDoctorModal = $("#idDoctorModal").val();
    let idPetModal = $("#idPetModal").val();
    let idClienteModal = $("#idClienteModal").val();
    let motiveModal = $("#motiveModal").val();
    let arrivalModal = $("#arrivalModal").val();
    let attentionModal = $("#attentionModal").val();
    let idProduct = $("#idProduct").val();
    let idService = $("#idService").val();
    let statusP = $("#statusP").val();

    if (statusP === '1') {
        statusP = true;
    } else {
        statusP = false;
    }

    $.ajax({
        type: "PUT",
        url: "../Forms/UpdateForms",
        dataType: "json",
        data: {
            "idMedicalRecord": idMedicalRecord,
            "idUser": idDoctorModal,
            "idPet": idPetModal,
            "idClient": idClienteModal,
            "motive": motiveModal,
            "arrival": arrivalModal,
            "attention": attentionModal,
            "idProduct": idProduct,
            "idService": idService,
            "statusP": statusP
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Se actualizo correctamente.',
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
                title: 'Erorr',
                text: 'Lo sentimos ha ocurrido un error.',
            });

        }
    });

}


let id = 0;
function OpenDeleteConfirmFormsModal(idMedicalRecord) {
    id = idMedicalRecord;
    $('#deleteFormsModal').modal('show');
}

function DeleteForms() {
    $.ajax({
        type: "DELETE",
        url: "../Forms/DeleteForms?idMedicalRecord=" + id,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Eliminado correctamente.',
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
                title: 'Erorr',
                text: 'Lo sentimos ha ocurrido un error.',
            });

        }
    });
}


$('#idClienteModal').on('change', function () {
    //alert(this.value);
    GetPetsByIdClient(this.value);
});

function GetPetsByIdClient(idClient) {
    $.ajax({
        type: "GET",
        url: "../Forms/GetPetsByIdClient?idClient=" + idClient,
        dataType: "json",
        success: function (res) {

            $('#idPetModal').empty().append(' <option value="0">Seleccione una Mascota</option>');

            Object.keys(res).forEach(function (key) {

                let optionText = res[key].petName;
                let optionValue = res[key].idPet;

                $('#idPetModal').append(new Option(optionText, optionValue));
            });

        }
    });
}

function validateInputs() {

    let idDoctorModal = $("#idDoctorModal").val();
    let idPetModal = $("#idPetModal").val();
    let idClienteModal = $("#idClienteModal").val();
    let motiveModal = $("#motiveModal").val();
    let arrivalModal = $("#arrivalModal").val();
    let attentionModal = $("#attentionModal").val();
    let idProduct = $("#idProduct").val();
    let idService = $("#idService").val();
    let statusP = $("#statusP").val();

    idClienteModalMessage.text("");
    idPetModalModalMessage.text("");
    idDoctorModalMessage.text("");
    arrivalModalMessage.text("");
    attentionModalMessage.text("");
    idProductModalMessage.text("");
    idServiceModalMessage.text("");
    statusPModalMessage.text("");
    motiveModalMessage.text("");

    if (idClienteModal === '0') {
        idClienteModalMessage.text("Debe seleccionar un cliente.");
        return false;
    }

    if (idPetModal === '0') {
        idPetModalModalMessage.text("Debe seleccionar una mascota.");
        return false;
    }

    if (idDoctorModal === '0') {
        idDoctorModalMessage.text("Debe seleccionar un doctor.");
        return false;
    }
    if (arrivalModal.trim().length === 0) {
        arrivalModalMessage.text("Hora llegada no puerde ir vac\u00EDo.");
        return false;
    }

    if (idProduct === '0' && idService === '0') {
        idProductModalMessage.text("Debe selecccionar un producto o un servicio.");
        idServiceModalMessage.text("Debe selecccionar un producto o un servicio.");
        return false;
    }

    if (statusP === '') {
        statusPModalMessage.text("Debe seleccionar un Estado Pago.");
        return false;
    }

    return true;
}

function validateFormMonth(date) {

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

function validateFormDay(date) {

    let day = date.getDate();

    if (day <= 9) {

        day = '0' + day;

        return day;
    }

    return day;
}

function validateFormHour(time) {

    let hour = time.getHours()

    if (hour <= 9) {
        hour = '0' + hour;
        return hour;
    }

    return hour;
}

function validateFormMinutes(time) {

    let minutes = time.getMinutes()

    if (minutes <= 9) {
        minutes = '0' + minutes;
        return minutes;
    }

    return minutes;
}
