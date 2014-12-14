$(document).ready(function () {
    var $checkBoxes = $("input[name=initiative_0]");
    $checkBoxes.on('click', function () {
        $(this).next().next().attr('display', 'block');
    });
});