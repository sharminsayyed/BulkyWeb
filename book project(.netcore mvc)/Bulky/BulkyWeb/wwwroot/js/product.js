var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    if ($.fn.DataTable.isDataTable('#data')) {
        $('#data').DataTable().clear().destroy();
    }

    dataTable = $('#data').DataTable({
        "ajax": {
            "url": '/admin/product/getall',
            "dataSrc": "data"
        },
        "columns": [
            { data: 'title', "width": "15%" },
            { data: 'isbn', "width": "15%" },
            { data: 'listPrice', "width": "15%" },
            { data: 'author', "width": "15%" },
            { data: 'category.name', "width": "15%" }
        ]
    });
}