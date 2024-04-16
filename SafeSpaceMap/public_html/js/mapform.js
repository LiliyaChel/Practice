/*eslint-env es6*/
/*eslint-env jquery*/
/*eslint-env browser*/
/*eslint no-console: 0*/
'use strict';

let markersData = [];
let groupedMarkers = new Map();
let lat = -1; 
let long = -1;
let map;

DG.then(function() {
            return DG.plugin('https://unpkg.com/leaflet.markercluster@1.4.1/dist/leaflet.markercluster.js');
            }).then(function() {
                let markers = DG.markerClusterGroup();
                map = DG.map('map', {
                    center: [59.935236464617034, 30.335769651574086],
                    zoom: 15
                    });
                map.zoomControl.setPosition('bottomleft');
                map.fullscreenControl.setPosition('bottomleft');
                map.locate({setView: true, watch: true})
                    .on('locationfound', function(e) {
                    })
                handleMarkersData(map, markers);
            
                let smallMap;
                let mark = DG.marker();
                smallMap = DG.map('smallMap', {
                    center: [59.935236464617034, 30.335769651574086],
                    zoom: 15
                    });
        
                smallMap.locate({setView: true, watch: true})
                        .on('locationfound', function(e) {
                        })
                smallMap.on('click', function(e) {
                        lat = e.latlng.lat;
                        long = e.latlng.lng;
                        mark.setLatLng([lat,long]);
                        mark.addTo(smallMap);
                        $('.popup').stop().animate({
                          scrollTop: $('.popup')[0].scrollHeight
                        }, 800);
                    });        

            });

interfaceInit();

function handleMarkersData(map, markers) {
    jQuery.ajax({
        url:     "../php/mapform-markers-data-ajax.php",
        type:     "POST",
        dataType: "html",
        success: function(response) {
            if (response == -1) { alert("Не удалось подключится к базе данных."); }
            else if (response == -2) { alert("Произошла ошибка при выполнении запроса."); }
            else if (response != -3) { 
                markersData = jQuery.parseJSON(response);
                groupMarkers(map, markers);
                showMarkersOnMap(map, markers);
            }
            //иначе данные пусты
    	},
    	error: function(response) { alert("Произошла ошибка при выполнении AJAX."); }
 	});
}

function showMarkersOnMap(map){
        for(let value of groupedMarkers.values()) { 
        value.addTo(map); 
    }
}

function groupMarkers(map, markers){
    for (let i = 0; i < markersData.length; i++){
        let temp = DG.markerClusterGroup();
        if (!(groupedMarkers.has(markersData[i][4]))) groupedMarkers.set(markersData[i][4],temp);
        temp = groupedMarkers.get(markersData[i][4]);
        DG.marker([markersData[i][1], markersData[i][2]]).addTo(temp).bindPopup(markersData[i][5]).bindLabel(markersData[i][6]);
        groupedMarkers.set(markersData[i][4], temp);
    }
}

function interfaceInit() {
  let newMarkForm = document.querySelector("#newMarkForm");
  newMarkForm.onsubmit = submitNewMarkForm;
  categoryButtonsInit();
}

function submitNewMarkForm(event) {
    event.preventDefault();
    if (lat == -1 || long == -1) { alert('Вы не выбрали точку на карте!'); }
    else {
         jQuery.ajax({
            url:     "../php/add-new-mark-ajax.php",
            type:     "POST",
            dataType: "html",
            data: jQuery("#newMarkForm").serialize() + '&lati=' + lat + '&longi=' + long,
            success: function(response) {
                if (response == 1) {
                    $('.close-popup')[0].click();
                    setTimeout(function(){ alert("Спасибо, успешно отправлено на модерацию!"); }, 100);
                    jQuery("#newMarkForm").trigger('reset');
                }
                else if (response == -1) { alert("Не удалось подключится к базе данных."); }
                else if (response == -2) { alert("Произошла ошибка при выполнении запроса."); }
                else { alert("От сервера получен некорректный ответ - результат неизвестен."); }
        	},
        	error: function(response) { alert("Произошла ошибка при выполнении AJAX."); }
     	});
    }
}

function removeMarkers(map){ 
     for(let value of groupedMarkers.values()) { 
        value.removeFrom(map); 
     }
}

function showGroup(id){ 
    removeMarkers(map);
    if (id == -1) {
        showMarkersOnMap(map);
    }
    else {
        for(let [key, value] of groupedMarkers) { 
            if (key == id) {
                value.addTo(map);
                break;
            }
        }
    }
}

function categoryButtonsInit() {
    let buttons = document.querySelectorAll('.categoryBtn');
    for (let button of buttons) {
    button.onclick = function() {
        if (button.id == 'allGroupsBtn') showGroup(-1);
        else {
            let idToShow = button.id.match(/(\d+)/)[0];
            showGroup(idToShow);
        }
      }
    }
}


/*Dropdown Menu*/
$('.dropdown').click(function () {
        $(this).attr('tabindex', 1).focus();
        $(this).toggleClass('active');
        $(this).find('.dropdown-menu').slideToggle(300);
    });
    $('.dropdown').focusout(function () {
        $(this).removeClass('active');
        $(this).find('.dropdown-menu').slideUp(300);
    });
    $('.dropdown .dropdown-menu li').click(function () {
        $(this).parents('.dropdown').find('.active-category').text($(this).text());
    });
/*End Dropdown Menu*/