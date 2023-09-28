$("[ImageInput]").change(function () {
    var x = $(this).attr("ImageInput");
    if (this.files && this.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("[ImageFile=" + x + "]").attr('src', e.target.result);
        };
        reader.readAsDataURL(this.files[0]);
    }
});

function fillPage(page){
    $('#filter-form-page').val(page);
    submitFilterForm();
}

function submitFilterForm(){
    $('#filter-form').submit();
}

$('#filter-form-take').on('change', function (){
    submitFilterForm();
});