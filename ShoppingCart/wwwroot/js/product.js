$(document).ready(function () {

    $('#myTable').DataTable({
        "ajax": { url: '/product/GetAllProducts' },
        "columns": [
            { data: 'title', "width": "15%" },

            { data: 'isbn', "width": "15%" },
            { data: 'author', "width": "15%" },
            { data: 'listPrice', "width": "15%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id',
                "width": "15%",
                "render": function (data) {
                    return `<div>
                        <div class="m-75 btn-group">
						<a href="/product/UpsertProduct?id${data}" 
					   class="btn btn-primary mx-2">
							<i class="bi bi-pencil-square"></i>Edit
						</a>

                      <a href="/product/Delete?id${data}" onclick="myFunction(); return false;"

					   class="btn btn-danger mx-2">
							<i class="bi bi-trash-fill"></i>Delete
						</a>
					</div>
                            </div>
                            <script>
                          function myFunction() {
                            
                                    Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                }
            })
                                    }
                           </script>`
                }
            },
        ],


    });
});