$(document).on("click", "#btnAddSupplier", function () {

    $("#idSupplierModal").prop("readonly", false);
    $("#supplierNameModal").prop("readonly", false);
    $("#supplierPhoneNumberModal").prop("readonly", false);
    $("#supplierIdCardModal").prop("readonly", false);

    $("#idSupplierModal").val('');
    $("#supplierNameModal").val('');
    $("#supplierPhoneNumberModal").val('');
    $("#supplierIdCardModal").val('');


    let supplierNameMessage = $("#supplierNameModalMessage");
    let supplierIdCardMessage = $("#supplierIdCardModalMessage");
    let supplierPhoneNumberMessage = $("#supplierPhoneNumberModalMessage");


    supplierNameMessage.text("");
    supplierIdCardMessage.text("");
    supplierPhoneNumberMessage.text("");


    $('#suppliersModal').modal('show');

});



function SavaChangesSupplierModal() {

    let idSupplier= $("#idSupplierModal").val();

    let validateInput = validateSupplierInputs();
    let validateSupplierIdCardMessage = ValidateSupplierIdCard();
    let validatePhoneNumberMessage = validateSupplierPhoneNumber();

    if (validateInput && validateSupplierIdCardMessage && validatePhoneNumberMessage) {

        if (idSupplier.trim().length === 0) {
            CreateSupplier();
        } else {
            UpdateSupplier();
        }

    }


}

function CreateSupplier() {
    let supplierName = $("#supplierNameModal").val();
    let supplierPhoneNumber = $("#supplierPhoneNumberModal").val();
    let supplierIdCard = $("#supplierIdCardModal").val();

    $.ajax({
        type: "POST",
        url: "../Supplier/CreateSupplier",
        dataType: "json",
        data: {
            "supplierName": supplierName,
            "supplierPhoneNumber": supplierPhoneNumber,
            "supplierIdCard": supplierIdCard
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Proveedor registrado correctamente.',
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

function OpenUpdateSupplierModal(idSupplier) {
    $.ajax({
        type: "GET",
        url: "../Supplier/GetSupplier?idSupplier=" + idSupplier,
        dataType: "json",
        success: function (res) {

            $("#supplierNameModal").prop("readonly", true);
            $("#supplierPhoneNumberModal").prop("readonly", false);
            $("#supplierIdCardModal").prop("readonly", true);


            $("#idSupplierModal").val(res.idSupplier);
            $("#supplierNameModal").val(res.supplierName);
            $("#supplierPhoneNumberModal").val(res.supplierPhoneNumber);
            $("#supplierIdCardModal").val(res.supplierIdCard);

            if (res.supplierIdCard.length === 9) {
                $("#selectsupplierIdCardModal").val('1');
            } else {
                $("#selectsupplierIdCardModal").val('2');
            }

            $('#suppliersModal').modal('show');

        }
    });
}

function UpdateSupplier() {

    let idSupplier = $("#idSupplierModal").val();
    let supplierName = $("#supplierNameModal").val();
    let supplierPhoneNumber = $("#supplierPhoneNumberModal").val();
    let supplierIdCard = $("#supplierIdCardModal").val();

    $.ajax({
        type: "PUT",
        url: "../Supplier/UpdateSupplier",
        dataType: "json",
        data: {
            "idSupplier": idSupplier,
            "supplierName": supplierName,
            "supplierPhoneNumber": supplierPhoneNumber,
            "supplierIdCard": supplierIdCard
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Proveedor actualizado correctamente.',
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

let idtempSupplier= 0;

function OpenDeleteConfirmSupplierModal(idSupplier) {
    idtempSupplier = idSupplier;
    $('#deleteSupplierModal').modal('show');
}

function DeleteSupplier() {
    $.ajax({
        type: "DELETE",
        url: "../Supplier/DeleteSupplier?idSupplier=" + idtempSupplier,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Proveedor eliminado correctamente.',
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
                text: 'El proveedor no puede ser eliminado, ya que esta siendo utilizado en otras funcionalidades del sistema.',
            });

        }
    });
}

function ValidateSupplierIdCard() {

    let idUser = $("#idSupplierModal").val();
    let supplierIdCardMessage = $("#supplierIdCardModalMessage");
    if (idUser.trim().length === 0) {

        let userIdCard = $("#supplierIdCardModal").val();
        let selectUserIdCard = $("#selectsupplierIdCardModal").val();

        supplierIdCardMessage.text("");


        if (selectUserIdCard === '1') {

            if (userIdCard.trim().length < 9) {
                supplierIdCardMessage.text("C\u00E9dula no puede ser menor a 9 d\u00EDgitos.");
                return false;
            }

            if (userIdCard.trim().length > 9) {
                supplierIdCardMessage.text("C\u00E9dula no puede ser mayor a 9 d\u00EDgitos.");
                return false;
            }

            return true;
        }

        if (selectUserIdCard === '2') {

            if (userIdCard.trim().length < 10) {
                supplierIdCardMessage.text("C\u00E9dula no puede ser menor a 10 d\u00EDgitos.");
                return false;
            }

            if (userIdCard.trim().length > 10) {
                supplierIdCardMessage.text("C\u00E9dula no puede ser mayor a 10 d\u00EDgitos.");
                return false;
            }

            return true;
        }

        if (selectUserIdCard === '3') {

            if (userIdCard.trim().length < 12) {
                supplierIdCardMessage.text("DIMEX no puede ser menor a 12 d\u00EDgitos.");
                return false;
            }

            if (userIdCard.trim().length > 12) {
                supplierIdCardMessage.text("DIMEX no puede ser mayor a 12 d\u00EDgitos.");
                return false;
            }

            return true;
        }

        return true;

    }
    return true;
}

function ValidatesupplierIdCardExist() {


    let idUser = $("#idSupplierModal").val();
    let supplierIdCardMessage = $("#supplierIdCardModalMessage");

    if (idUser.trim().length === 0) {

        let userIdCard = $("#supplierIdCardModal").val()

        const button = document.getElementById("btnGuardarModal");

        // Disable the button
        button.disabled = true;
        supplierIdCardMessage.text("");

        $.ajax({
            type: "GET",
            url: "../Supplier/ValidateSupplierIdCardExist?supplierIdCard=" + userIdCard,
            dataType: "json",
            success: function (res) {

                if (res === null) {
                    button.disabled = false;

                } else {
                    supplierIdCardMessage.text("La c\u00E9dula ingresada ya existe en el sistema.");
                    button.disabled = true;
                }

            }
        });
    }

}

function validateSupplierPhoneNumber() {

    let userPhoneNumber = $("#supplierPhoneNumberModal").val();
    let supplierPhoneNumberMessage = $("#supplierPhoneNumberModalMessage");
    supplierPhoneNumberMessage.text("");

    if (userPhoneNumber.trim().length < 8) {
        supplierPhoneNumberMessage.text("Tel\u00E9fono tiene que ser de ocho d\u00EDgitos.");
        return false;
    }

    if (userPhoneNumber.trim().length > 8) {
        supplierPhoneNumberMessage.text("Tel\u00E9fono no puede tener m\u00E1s de ocho d\u00EDgitos.");
        return false;
    }

    return true;
}

$('#selectsupplierIdCardModal').on('change', function () {
    //alert(this.value);
    let supplierIdCardMessage = $("#supplierIdCardModalMessage");
    supplierIdCardMessage.text("");
});

function validateSupplierInputs() {

    let supplierName = $("#supplierNameModal").val();
    let supplierIdCard = $("#supplierIdCardModal").val();
    let supplierPhoneNumber = $("#supplierPhoneNumberModal").val()

    let supplierNameMessage = $("#supplierNameModalMessage");
    let supplierIdCardMessage = $("#supplierIdCardModalMessage");
    let supplierPhoneNumberMessage = $("#supplierPhoneNumberModalMessage");


    supplierNameMessage.text("");
    supplierIdCardMessage.text("");
    supplierPhoneNumberMessage.text("");

    if (supplierName.trim().length === 0) {
        supplierNameMessage.text("Nombre no puede ir vac\u00EDo.");
        return false;
    }

    if (supplierIdCard.trim().length === 0) {
        supplierIdCardMessage.text("C\u00E9dula fiscal no puede ir vac\u00EDo.");
        return false;
    }

    if (supplierPhoneNumber.trim().length === 0) {
        supplierPhoneNumberMessage.text("Tel\u00E9fono no puede ir vac\u00EDo.");
        return false;
    }

    if (supplierPhoneNumber.trim().length < 8) {
        supplierPhoneNumberMessage.text("Debe tener m\u00EDnimo 8 n\u00FAmeros.");
        return false;
    }

    return true;
}