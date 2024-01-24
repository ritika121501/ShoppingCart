$(document).ready(function () {

    $('#myTable').DataTable({
        "ajax": { url: '/Company/GetAllCompany' },
        "columns": [
            { data: 'companyName', "width": "15%" },
            { data: 'streetAddress', "width": "15%" },
            { data: 'city', "width": "15%" },
            { data: 'state', "width": "15%" },
            { data: 'postal', "width": "15%" },
            { data: 'phoneNumber', "width": "15%" },


            {
                data: 'companyId',
                "width": "15%",
                "render": function (data) {
                    return `<div>
                        <div class="m-75 btn-group">
<a href="/Company/UpsertCompany/${data}"
  class="btn btn-primary mx-2">
<i class="bi bi-pencil-square"></i>Edit
</a>

                      <a href="/company/Delete/${data}" onclick="return myFunction();"

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
               
                //if (result.isConfirmed) {
                //    Swal.fire(
                //        'Deleted!',
                //        'Your file has been deleted.',
                //        'success'
                //    )
                //}

                if (result.isConfirmed)
                {
                $.ajax({
                        url: '/company/Delete/${data}',
                        type: 'GET',
                        data: { id: ${data} },
                        success: function () {
                            // Remove the row from DataTable on success
                            //row.remove().draw();
                            Swal.fire(
                                'Deleted!',
                                'Data has been deleted.',
                                'success'
                            ).then((a) => {
                                location.reload();
                            });
                          
                        },
                        error: function () {
                            // Handle error if needed
                            Swal.fire(
                                'Error!',
                                'Failed to delete data.',
                                'error'
                            );
                        }
                    });
                    }

            });
            return false;
                                    }
                           </script>`
                }
            },
        ],


    });
});
