function createImagesPreviewer(selector, items) {
    var galleryContainer = document.querySelector(selector);

    var containerSize = {
        width: 700,
        height: 350
    };

    var galleryFragment = document.createDocumentFragment();
    var leftSideBar = null;
    var rightSideBar = null;
    var filterTitle = null;
    var filterInput = null;
    var animalCollection = null;
    var animalsContainer = document.createElement('div');
    var sideBarPattern = document.createElement('div');
    var animalImageContainerPattern = document.createElement('div');
    var animalImagePattern = document.createElement('img');
    var titlePattern = document.createElement('h4');
    var leftSideTitlePattern = document.createElement('h1');
    var lefSideImagePattern = document.createElement('img');

    applyGalleryContainerStyles(galleryContainer, containerSize);
    applySideBarStyles(sideBarPattern, containerSize);
    applyAnimalsContainerStyles(animalsContainer);
    applyAnimalImageContainerStyles(animalImageContainerPattern);
    leftSideBar = setLeftSideBar(sideBarPattern, containerSize);
    rightSideBar = setRightSideBar(sideBarPattern, containerSize);
    filterTitle = addFilterTitle();
    filterInput = addFilterInput(rightSideBar);
    applyAnimalImageStyles(animalImagePattern, rightSideBar);
    animalCollection = generateAnimals(animalsContainer, items);
    attachEventsToRightSideAnimals(animalsContainer);
    attachEventsToInputFilter(filterInput);

    addAnimalsToContainer(animalsContainer, animalCollection);
    rightSideBar.appendChild(filterTitle);
    rightSideBar.appendChild(filterInput);
    rightSideBar.appendChild(animalsContainer);
    generateFirstAnimalPreview(leftSideBar, items[0]);
    galleryFragment.appendChild(leftSideBar);
    galleryFragment.appendChild(rightSideBar);

    function applyGalleryContainerStyles(galleryContainer, containerSize) {
        galleryContainer.style.border = '1px solid black';
        galleryContainer.style.height = containerSize.height + 'px';
        galleryContainer.style.width = containerSize.width + 'px';
        galleryContainer.style.textAlign = 'center';
    }

    function addFilterInput(rightSideBar) {
        var rightSideBarWidth = parseInt(rightSideBar.style.width);
        var filterBox = document.createElement('input');
        filterBox.setAttribute("type", "text");
        filterBox.className += " filterBox";
        filterBox.style.display = "block";
        filterBox.style.width = (rightSideBarWidth - 35) + 'px';
        filterBox.style.margin = '0 auto';
        return filterBox;
    }

    function addFilterTitle() {
        var title = titlePattern.cloneNode(true);
        title.innerText = 'Filter';
        title.style.fontWeight = 'normal';
        title.style.margin = 0;
        return title;
    }

    function applySideBarStyles(sideBar, containerSize) {
        sideBar.style.height = containerSize.height + 'px';
        sideBar.style.verticalAlign = 'top';
        sideBar.style.textAlign = 'center';
        sideBar.style.display = 'inline-block';
        //sideBar.style.border = '1px solid red';
    }

    function setLeftSideBar(sideBarPattern, containerSize) {
        var leftBar = sideBarPattern.cloneNode(true);
        leftBar.style.width = parseInt(containerSize.width * 0.6 - 4) + 'px';
        return leftBar;
    }

    function setRightSideBar(sideBarPattern, containerSize) {
        var rightBar = sideBarPattern.cloneNode(true);
        rightBar.style.width = parseInt(containerSize.width * 0.4 - 4) + 'px';
        rightBar.style.overflowX = 'hidden';
        rightBar.style.overflowY = 'auto';
        return rightBar;
    }

    function generateAnimals(animalsContainer, animals) {
        var animalList = [];
        for (var i = 0; i < animals.length; i++) {
            var currentanimal = animals[i];
            var currentAnimalContainer = generateAnimalContainer(currentanimal.url, currentanimal.title);
            animalList.push(currentAnimalContainer);
        }

        return animalList;
    }

    function generateAnimalContainer(url, title) {
        var currentAnimalContainer = animalImageContainerPattern.cloneNode(true);
        var currentAnimalImage = generateAnimalImage(url);
        var currentAnimalTitle = generateAnimalTitle(title);
        currentAnimalContainer.setAttribute('animal-data', title.toLowerCase());
        currentAnimalContainer.appendChild(currentAnimalTitle);
        currentAnimalContainer.appendChild(currentAnimalImage);
        return currentAnimalContainer;
    }

    function generateAnimalImage(path) {
        var currentAnimalImage = animalImagePattern.cloneNode(true);
        currentAnimalImage.setAttribute("src", path);
        return currentAnimalImage;
    }

    function generateAnimalTitle(title) {
        var currentanimalTitle = titlePattern.cloneNode(true);
        currentanimalTitle.innerText = title;
        return currentanimalTitle;
    }

    function applyAnimalImageStyles(animalImagePattern, rightSideBar) {
        var rightSideBarWidth = parseInt(rightSideBar.style.width);
        animalImagePattern.style.width = (rightSideBarWidth - 35) + 'px';
        animalImagePattern.style.borderRadius = '10px';
    }

    function applyAnimalsContainerStyles(animalsContainer) {
        animalsContainer.className += 'animals-container';
    }

    function addAnimalsToContainer(animalsContainer, animalCollection) {
        for (var i = 0; i < animalCollection.length; i++) {
            var animalElement = animalCollection[i];
            animalsContainer.appendChild(animalElement);
        }
    }

    function attachEventsToRightSideAnimals(animalsContainer) {
        animalsContainer.addEventListener("mouseover", function (e) {
            if (e.target && e.target.nodeName == "DIV" && e.target.className.indexOf('animalImg-container') >= 0) {
                e.target.style.backgroundColor = 'lightgray';
            } else if (e.target && e.target.nodeName == 'H4' || e.target.nodeName == 'IMG') {
                e.target.parentNode.style.backgroundColor = 'lightgray';
            }
        }, false);

        animalsContainer.addEventListener("mouseout", function (e) {
            if (e.target && e.target.nodeName == "DIV" && e.target.className.indexOf('animalImg-container') >= 0) {
                e.target.style.backgroundColor = 'white';
            } else if (e.target && e.target.nodeName == 'H4' || e.target.nodeName == 'IMG') {
                e.target.parentNode.style.backgroundColor = 'white';
            }
        }, false);

        animalsContainer.addEventListener("click", function (e) {
            if (e.target && e.target.nodeName == "DIV" && e.target.className.indexOf('animalImg-container') >= 0) {
                var src = e.target.getElementsByTagName[0].getAttribute('animal-data');
                var title = e.target.getElementsByTagName('h4')[0].innerText;
                previewElement(src, title);
            } else if (e.target && e.target.nodeName == 'H4' || e.target.nodeName == 'IMG') {
                var src = e.target.parentNode.getElementsByTagName('img')[0].getAttribute('src');
                var title = e.target.parentNode.getElementsByTagName('h4')[0].innerText;
                previewElement(src, title);
            }
        }, false);
    }

    function applyAnimalImageContainerStyles(containerPattern) {
        containerPattern.className += ' animalImg-container';
        containerPattern.style.margin = 0;
        containerPattern.style.verticalAlign = 'top';
    }

    function previewElement(src, title) {
        var previewIMG = leftSideBar.querySelector('.previewImage');
        var previewTitle = leftSideBar.querySelector('.previewTitle');
        previewTitle.innerText = title;
        previewIMG.setAttribute('src', src);
    }

    function generateFirstAnimalPreview(leftSideBar, item) {
        var title = leftSideTitlePattern.cloneNode(true);
        title.className += 'previewTitle';
        title.innerText = item.title;
        var img = lefSideImagePattern.cloneNode(true);
        img.className += 'previewImage';
        img.style.width = parseInt(containerSize.width * 0.6 - 120) + 'px';
        img.setAttribute('src', item.url);
        img.style.borderRadius = '10px';
        leftSideBar.appendChild(title);
        leftSideBar.appendChild(img);
    }

    function attachEventsToInputFilter(filterInput) {
        filterInput.addEventListener("input", function (e) {
            if (!e) {
                return;
            }

            var searchedTitle = e.target.value;
            filterElements(searchedTitle);
        }, false);
    }

    function filterElements(searchedTitle) {
        var rightSideAnimals = galleryContainer.querySelectorAll('.animals-container .animalImg-container');
        var isSearching = searchedTitle.trim().length != 0;
        for (var i = 0; i < rightSideAnimals.length; i++) {
            var animal = rightSideAnimals[i];
            if (isSearching && animal.getAttribute('animal-data').toLowerCase().indexOf(searchedTitle.toLowerCase()) == -1) {
                animal.style.display = 'none';
            } else {
                animal.style.display = '';
            }
        }
    }

    galleryContainer.appendChild(galleryFragment);
}