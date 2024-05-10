"use strict";
$(document).ready(function () {
    $("#datatable").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
        },
        "ordering": false,
        "bDestroy": true
    });
    var a = $("#datatable-buttons").DataTable({
        lengthChange: !1,
        buttons: ["copy", "excel", "pdf"],
        "ordering": false,
    });
    $("#key-table").DataTable({
        keys: !0
    }), $("#responsive-datatable").DataTable(), $("#selection-datatable").DataTable({
        select: {
            style: "multi"
        }
    }), a.buttons().container().appendTo("#datatable-buttons_wrapper .col-md-6:eq(0)"), $("#datatable_length select[name*='datatable_length']").addClass("form-select form-select-sm"), $("#datatable_length select[name*='datatable_length']").removeClass("custom-select custom-select-sm"), $(".dataTables_length label").addClass("form-label")
});