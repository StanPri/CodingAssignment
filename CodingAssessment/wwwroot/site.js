const uri = 'api/OutputMessage';
let OutputMessages = null;
function getCount(data) {
    const el = $('#counter');
    let message = 'Output Message';
    if (data) {
        if (data > 1) {
            message = 'Output Messages';
        }
        el.text(data + ' ' + message);
    } else {
        el.html('No ' + message);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#OutputMessages').empty();
            getCount(data.length);
            $.each(data, function (key, item) {

                $('<tr>' +
                    '<td>' + item.message + '</td>' +
                    '<td><button onclick="editItem(' + item.id + ')">Edit</button></td>' +
                    '<td><button onclick="deleteItem(' + item.id + ')">Delete</button></td>' +
                    '</tr>').appendTo($('#OutputMessages'));
            });

            OutputMessages = data;
        }
    });
}

function addItem() {
    const item = {
        'message': $('#add-message').val(),
        'isComplete': false
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getData();
            $('#add-message').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(OutputMessages, function (key, item) {
        if (item.id === id) {
            $('#edit-message').val(item.message);
            $('#edit-id').val(item.id);
            $('#edit-isComplete').val(item.isComplete);
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const item = {
        'message': $('#edit-message').val(),
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}