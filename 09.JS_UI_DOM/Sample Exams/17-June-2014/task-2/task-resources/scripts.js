/* globals $ */
$.fn.gallery = function (columns) {

    columns = columns || 4;

    var $this = $(this);
    $this.addClass('gallery');

    var $selected = $this.find('.selected');

    var $prevImage = $selected.find('#previous-image');
    var $currentImage = $selected.find('#current-image');
    var $nextImage = $selected.find('#next-image');

    $selected.hide();
    var imageContainers = $this.find('.image-container');

    var count = 0;
    $(imageContainers).each(function (index, imageContainer) {
        var $imageContainer = $(imageContainer);
        if (index % (columns) === 0 && index !== 0) {
            $imageContainer.addClass('clearfix');
        }
    })


    $('.gallery-list').on('click', '.image-container img', function () {
        var $this = $(this);
        $('<div />').appendTo($('#gallery')).addClass('disabled-background');
        $this.parent().parent().addClass('blurred')
        $selected.show();

        console.log($selected.find('#current-image'));

        if(!$this.parent().next().children().first().attr('src')){
            $nextImage.attr('src',$('.gallery-list .image-container img').first().attr('src'))
        }
        else{
            $nextImage.attr('src', $this.parent().next().children().first().attr('src'));
        }

        if(!$this.parent().prev().children().first().attr('src')){
            $prevImage.attr('src',$('.gallery-list .image-container img').last().attr('src'))
        }
        else{
            $prevImage.attr('src', $this.parent().prev().children().first().attr('src'));
        }



        $currentImage.attr('src', $this.attr('src'));

    })
    
    $currentImage.on('click', function(){
        $selected.hide();
        //$this.parent().parent().removeClass('blurred')
        $('.gallery-list').removeClass('blurred')
        $('.disabled-background').remove();
    })

    $prevImage.on('click', function () {
        var $this = $(this);
        $nextImage.attr('src', $currentImage.attr('src'))
        $currentImage.attr('src', $this.attr('src'));


        
        var prevDiv = $('.gallery-list img').filter(function(index, item){
            return $(item).attr('src')===$this.attr('src');
        });

        //console.log(prevDiv.parent());



        if (!$(prevDiv).parent().prev().attr('class')) {

            var div = $('.gallery-list .image-container').last();
            console.log(div);
            $this.attr('src',$(div).children().first().attr('src'))
        }
        else {
            $this.attr('src', $(prevDiv).parent().prev().children().first().attr('src'));
        }



    })

    $nextImage.on('click', function () {
        var $this = $(this);
        $prevImage.attr('src', $currentImage.attr('src'))
        $currentImage.attr('src', $this.attr('src'));



        var prevDiv = $('.gallery-list img').filter(function(index, item){
            return $(item).attr('src')===$this.attr('src');
        });

        //console.log(prevDiv.parent());



        if (!$(prevDiv).parent().next().attr('class')) {

            var div = $('.gallery-list .image-container').first();
            //console.log(div);
            $this.attr('src',$(div).children().first().attr('src'))
        }
        else {
            $this.attr('src', $(prevDiv).parent().next().children().first().attr('src'));
        }



    })


};