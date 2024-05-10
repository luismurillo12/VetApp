//Messages
let idClientMessage = $("#idClientMessage");
let hourMessage = $("#hourMessage");
let dayDateMessage = $("#dayDateMessage");
let idDoctorMessage = $("#idDoctorMessage");

$(document).ready(function () {
    let minDate = new Date();
    let minDateConversion = minDate.getFullYear() + '-' + validateMonth(minDate) + '-' + validateDay(minDate);
    $("#dayDate").attr('min', minDateConversion);
    $("#dateReason").attr('maxlength', '20');
});

$(document).on("click", "#btnAddAppointment", function () {

    $("#idDate").val('');
    $("#idClient").val('0');
    $("#dateReason").val('');
    $("#hour").val('');
    $("#dayDate").val('');
    $("#idDoctor").val('0');

    $('#appointmentModal').modal('show');

});


function SaveChangesAppointmentModal() {

    let idDate = $("#idDate").val();

    let validate = validateAppointmentInputs();

    if (validate) {
        if (idDate.trim().length === 0) {
            ScheduleAppointment();
        } else {
            UpdateAppointment();
        }
    }

}

function ScheduleAppointment() {
    let idClient = $("#idClient").val();
    let dateReason = $("#dateReason").val();
    let dayDate = $("#dayDate").val();
    let hour = $("#hour").val();
    let dateHour = dayDate + ' ' + hour;
    let idDoctor = $("#idDoctor").val();

    $.ajax({
        type: "POST",
        url: "../Appointment/ScheduleAppointment",
        dataType: "json",
        data: {
            "idClient": idClient,
            "dateReason": dateReason,
            "dateHour": dateHour,
            "idDoctor": idDoctor
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Cita agendada correctamente.',
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
                text: 'El Doctor ya cuenta con una cita agendada el día y hora ingresados.',
            });

        }
    });

}

function OpenUpdateAppointmentModal(idDate) {
    $.ajax({
        type: "GET",
        url: "../Appointment/GetAppointment?idDate=" + idDate,
        dataType: "json",
        success: function (res) {

            $("#idDate").val(res.idDate);
            $("#idClient").val(res.idClient);
            $("#dateReason").val(res.dateReason);
            $("#idDoctor").val(res.idDoctor);

            let date = new Date(res.appointmentDate);
            let dateConversion = date.getFullYear() + '-' + validateMonth(date) + '-' + validateDay(date);
            let hour = validateHour(date) + ':' + validateMinutes(date);

            $("#hour").val(hour);
            $("#dayDate").val(dateConversion);

            $('#appointmentModal').modal('show');

        }
    });
}


function UpdateAppointment() {

    let idDate = $("#idDate").val();
    let idClient = $("#idClient").val();
    let dateReason = $("#dateReason").val();
    let dayDate = $("#dayDate").val();
    let hour = $("#hour").val();
    let dateHour = dayDate + ' ' + hour;
    let idDoctor = $("#idDoctor").val();

    $.ajax({
        type: "PUT",
        url: "../Appointment/UpdateAppointment",
        dataType: "json",
        data: {
            "idDate": idDate,
            "idClient": idClient,
            "dateReason": dateReason,
            "dateHour": dateHour,
            "idDoctor": idDoctor
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Cita actualizada correctamente.',
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
                text: 'El Doctor ya cuenta con una cita agendada el día y hora ingresados.',
            });

        }
    });

}

let idDate = 0;
function OpenDeleteConfirmAppointmentModal(id) {
    idDate = id
    $('#deleteAppointmentModal').modal('show');
}

function DeleteAppointment() {

    $.ajax({
        type: "DELETE",
        url: "../Appointment/DeleteAppointment?idDate=" + idDate,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Cita eliminada correctamente.',
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

function validateAppointmentInputs() {

    let idClient = $("#idClient").val();
    let dayDate = $("#dayDate").val();
    let hour = $("#hour").val();
    let idDoctor = $("#idDoctor").val();

    idClientMessage.text("");
    dayDateMessage.text("");
    hourMessage.text("");
    idDoctorMessage.text("");

    if (idClient === '0') {
        idClientMessage.text("Debe seleccionar un cliente.");
        return false;
    }

    if (idDoctor === '0') {
        idDoctorMessage.text("Debe seleccionar un Doctor.");
        return false;
    }

    if (dayDate.trim().length === 0) {
        dayDateMessage.text("Fecha no puede ir vac\u00EDa.");
        return false;
    }

    if (hour.trim().length === 0) {
        hourMessage.text("Hora no puede ir vac\u00EDa.");
        return false;
    }

    return true;
}

function validateMonth(date) {

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

function validateDay(date) {

    let day = date.getDate();

    if (day <= 9) {

        day = '0' + day;

        return day;
    }

    return day;
}

function validateHour(time) {

    let hour = time.getHours()

    if (hour <= 9) {
        hour = '0' + hour;
        return hour;
    }

    return hour;
}

function validateMinutes(time) {

    let minutes = time.getMinutes()

    if (minutes <= 9) {
        minutes = '0' + minutes;
        return minutes;
    }

    return minutes;
}