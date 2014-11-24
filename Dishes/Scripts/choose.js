   $("#formId").change(function () {
           func4();
       });


  

function func4() {

    var idList = new Array();
    var loopCounter = 0;
    $("input[name='List']:checked").each(function () {
        idList[loopCounter] = $(this).val();
        loopCounter += 1;
    });

    var obj = { Name: idList.toString() };

    $.ajax({
        url: 'FindByIngredients',
        type: 'post',
        data: obj,
        dataType: 'json',
        success: function (data) {
            var s = $("#formId").serialize();
            $("#dishes_list").empty();
            $.each(data, function (i) {
                $("#dishes_list").append("<li>" + this.Name + "</li>");
            });

        }
    });
}




    

