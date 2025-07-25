
//this is AJAX in action!
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#productData').DataTable({
        "ajax": {
            "url": "/admin/product/getall"
        },
        // with the help of the url we can get all the list of products and its columns
        "columns": [
            { "data": "title", "width": "22%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "10%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    //at edit it calls the uperst.html file which class upsert function fromt the controllers
                    // at delete it calls the just the delete api function 
                    return `<div class="btn-group w-75" role="group">
									<a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2">
										<i class="bi bi-pencil-square"></i> Edit
									</a>
									<a  onClick = Delete('/admin/product/delete/${data}')  class="btn btn-danger mx-2">
										<i class="bi bi-trash-fill"></i> Delete
									</a>
								</div>
                    
                    `
                    
                },
                "width": "25%"
            },
        ]
    });
}

// alert for delete button 
function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                typpe: "Delete",
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}