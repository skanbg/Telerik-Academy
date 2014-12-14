$(document).ready(function () {
    var $form = $('#form-upload');

    $('#add-input-file').on('click', function () {
        var count = $form.children('input[type="file"]').length;

        var $inputTypeFile = $('<input />')
            .attr('type', 'file')
            .attr('name', 'file_' + count);

        var $inputTypeCheckbox = $('<input />')
            .attr('type', 'checkbox')
            .attr('name', 'private_' + count);

        var $span = $('<span/>')
            .text('Private');

        var $hr = $('<hr/>');

        $form.prepend($hr).prepend($span).prepend($inputTypeCheckbox).prepend($inputTypeFile);
    });
});