$(document).on("click", "#btnAddProduct", function () {

    $("#productModal").prop("readonly", false);
    $("#productBuyCostModal").prop("readonly", false);
    $("#productSellCostModal").prop("readonly", false);

    $("#productModal").val('');
    $("#productBuyCostModal").val('');
    $("#productSellCostModal").val('');



    $('#productsModal').modal('show');

});

function SavaChangesProductModal() {
    let idProduct = $("#idProductModal").val();
    let validateInput = validateInputs();

    if (validateInput) {

        if (idProduct.trim().length === 0) {
            CreateProduct();
        } else {
            UpdateProduct();
        }

    }


}


function CreateProduct() {
    let product = $("#productModal").val();
    let idSupplier = $("#idSupplierModal").val();
    let productBuyCost = $("#productBuyCostModal").val();
    let productSellCost = $("#productSellCostModal").val();

    $.ajax({
        type: "POST",
        url: "../Product/CreateProduct",
        dataType: "json",
        data: {
            "product": product,
            "idSupplier": idSupplier,
            "productBuyCost": productBuyCost,
            "productSellCost": productSellCost,
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Producto registrado correctamente.',
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

function OpenUpdateProductModal(idProduct) {
    $.ajax({
        type: "GET",
        url: "../Product/GetProduct?idProduct=" + idProduct,
        dataType: "json",
        success: function (res) {

            $("#productModal").prop("readonly", false);
            $("#productBuyCostModal").prop("readonly", false);
            $("#productSellCostModal").prop("readonly", false);


            $("#idProductModal").val(res.idProduct);
            $("#productModal").val(res.product);
            $("#idSupplierModal").val(res.idSupplier);
            $("#productBuyCostModal").val(res.productBuyCost);
            $("#productSellCostModal").val(res.productSellCost);



            $('#productsModal').modal('show');

        }
    });
}

function UpdateProduct() {
    let idProduct = $("#idProductModal").val();
    let product = $("#productModal").val();
    let idSupplier = $("#idSupplierModal").val();
    let productBuyCost = $("#productBuyCostModal").val();
    let productSellCost = $("#productSellCostModal").val();



    $.ajax({
        type: "PUT",
        url: "../Product/UpdateProduct",
        dataType: "json",
        data: {
            "idProduct": idProduct,
            "product": product,
            "idSupplier": idSupplier,
            "productBuyCost": productBuyCost,
            "productSellCost": productSellCost,
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Producto actualizado correctamente.',
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

let idtempProduct = 0;

function OpenDeleteConfirmProductModal(idProduct) {
    idtempProduct = idProduct;
    $('#deleteProductModal').modal('show');
}

function DeleteProduct() {
    $.ajax({
        type: "DELETE",
        url: "../Product/DeleteProduct?idProduct=" + idtempProduct,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Producto eliminado correctamente.',
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
                text: 'El producto no puede ser eliminado, ya que esta siendo utilizado en otras funcionalidades del sistema.',
            });

        }
    });
}
function validateInputs() {

    let product = $("#productModal").val();
    let productBuyCost = $("#productBuyCostModal").val();
    let productSellCost = $("#productSellCostModal").val();


    let productMessage = $("#productModalMessage");
    let productBuyCostMessage = $("#productBuyCostModalMessage");
    let productSellCostMessage = $("#productSellCostModalMessage");



    productMessage.text("");
    productBuyCostMessage.text("");
    productSellCostMessage.text("");


    if (product.trim().length === 0) {
        productMessage.text("Nombre del producto no puede ir vac\u00EDo.");
        return false;
    }

    if (productBuyCost.trim().length === 0) {
        productBuyCostMessage.text("Pr\u00E9cio no puede ir vac\u00EDo.");
        return false;
    }

    if (productSellCost.trim().length === 0) {
        productSellCostMessage.text("Pr\u00E9cio no puede ir vac\u00EDo.");
        return false;
    }

    return true;
}