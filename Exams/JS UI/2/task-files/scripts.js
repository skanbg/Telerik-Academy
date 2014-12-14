$.fn.gallery = function (columnsPerRow) {
    $this = $(this);
    columnsPerRow = columnsPerRow || 4;

    $this.addClass('gallery')
        .css('width', (columnsPerRow * 262) + 'px');
    $this.children('.gallery-list').css('width', (columnsPerRow * 262) + 'px');
    $this.children('.selected').hide();

    $this.find('.gallery-list').on('click', 'img', onImgClick);


    function nextOrFirst($currentElement, $sourceImg) {
        var selection = $currentElement.find('.gallery-list img[data-info=' + (parseInt($sourceImg.attr('data-info')) + 1) + ']');
        return selection.length == 0 ? $currentElement.find('.image-container img').first() : selection;
    }

    function prevOrLast($currentElement, $sourceImg) {
        var selection = $currentElement.find('.gallery-list img[data-info=' + (parseInt($sourceImg.attr('data-info')) - 1) + ']');
        return selection.length == 0 ? $currentElement.find('.image-container img').last() : selection;
    }

    function onImgClick(ev, current) {
        $current = current ? $(current) : $(this);
        $self = $current;// $(this);
        //Blur gallery
        $this.addClass('disabled-background')
            .find('.gallery-list')
            .addClass('blurred');

        $sourceImg = $self;
        //console.log($sourceImg);
        $prevImg = prevOrLast($this, $sourceImg);
        $nextImg = nextOrFirst($this, $sourceImg);

        $this.find('#previous-image')
            .off('click')
            .attr('src', $prevImg.attr('src'))
            .attr('data-info', parseInt($prevImg.attr('data-info')))
            .on('click', function (ev) {
                onImgClick(ev, $prevImg);
            });
        $this.find('#current-image')
            .off('click')
            .attr('src', $sourceImg.attr('src'))
            .on('click', closePreview);
        $this.find('#next-image')
            .off('click')
            .attr('src', $nextImg.attr('src'))
            .attr('data-info', $nextImg.attr('data-info'))
            .on('click', onImgClick);

        //Show selected images
        $this.find('.selected').show();
        //Dispatch events
        $this.find('.gallery-list').off('click', 'img', onImgClick);
    }

    function goToPrev() {

    }

    function closePreview(ev) {
        $this.removeClass('disabled-background')
            .find('.gallery-list')
            .removeClass('blurred');

        //Hide selected images
        $this.find('.selected').hide();

        //Disattach events
        $this.find('.gallery-list').on('click', 'img', onImgClick);
    }

//    //Blurr gallery
//    $this.children('.gallery-list').addClass('blurred');
};