// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var count = 1;
$('tr').each(function () {
    $(this).attr('rowId', + count);
    count++;
});

function showDeleteConfirmation(id, rowId) {
    $('#deleteModal').modal('show');
    $('#deleteProductId').val(id);
    $('#deleteRowId').val(rowId);
}
44
$('#deleteModal #btnDeleteYes').click(function () {
    var id = $('#deleteProductId').val();
    $.ajax({
        type: 'DELETE',
        url: '/BrandProducts/DeleteConfirmed/',
        data: { id: id },
        success: function (result) {
            
            if (result.success == true) {
                //console.log(result);
                $('#deleteModal').modal('hide');

                var rowId = $('#deleteRowId').val();
                $('.table tr[rowId="' + rowId + '"]').remove();

                var message = $('<div class="alert alert-success slim-alert">Your product has been deleted.</div>').hide();
                $('.container').prepend(message);
                message.fadeIn();
                setTimeout(function () {
                    message.fadeOut(function () {
                        message.remove();
                    });
                }, 3000);

                    
            } else {    
                alert('Failed to delete product' + data.error);
            }
        },
        error: function (error) {
            alert('Failed to delete product' + data.error);
        }
    });
   
});

$('#deleteModal #btnDeleteNo').click(function () {
    $('#deleteModal').modal('hide');
});

$('#deleteModal #closeIcon').click(function () {
    $('#deleteModal').modal('hide');
});
