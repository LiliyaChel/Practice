/*eslint-env es6*/
/*eslint-env jquery*/
/*eslint-env browser*/
/*eslint no-console: 0*/
'use strict';

const checkboxIcon = '&#x2610;';
const checkedCheckboxIcon = '&#x1F5F9;';

let data = [];
let table = document.querySelector('#dataTable');
let entries = []; //массив со всеми строками таблицы
let entriesLeft = 0; //количество оставшихся для проверки записей

pageInit();

function pageInit() {
  let authForm = document.querySelector('#authForm');
  authForm.onsubmit = interfaceInit;
}

function interfaceInit(event) {
  event.preventDefault();
  handleAuthForm.bind(this)();
}

function handleData() {
    jQuery.ajax({
        url:     "php/admin-page-data-ajax.php",
        type:     "POST",
        dataType: "html",
        success: function(response) {
            if (response == -1) { alert('Не удалось подключится к базе данных.'); }
            else if (response == -2) { alert('Произошла ошибка при выполнении запроса.'); }
            else {
                tableInit();
                if (response != -3) { 
                    data = jQuery.parseJSON(response);
                    showDataInTable();
                    saveBtnInit();
                    deleteBtnInit();
                }
                else { 
                    disableSaveBtn();
                    disableDeleteBtn();
                    alert('Метки для проверки не поступали.'); 
                }
            }
    	},
    	error: function(response) { alert('Произошла ошибка при выполнении AJAX.'); }
 	});
}

function tableInit() {
  let menuContainer = document.querySelector('.menu-container');
  menuContainer.classList.remove('hidden');
}

function showDataInTable() {
  let counter = 0;
  for (let dataForEntry of data) {
    entriesLeft++;
    let entry = document.createElement('tr');
    entry.classList.add('entry');
    entry.id = 'entry' + counter;
    counter++;
    for (let attr in dataForEntry) {
      let attrNode = document.createElement('td');
      attrNode.innerHTML = dataForEntry[attr];
      entry.append(attrNode);
    }
    let checkboxEl = document.createElement('td');
    checkboxEl.classList.add('checkbox');
    checkboxEl.innerHTML = checkboxIcon;
    checkboxEl.onclick = checkboxClickHandling;
    entry.append(checkboxEl);
    entries.push(entry);
    table.append(entry);
  }
}

function checkboxClickHandling() {
  if (this.classList.contains('checked')) {
    this.classList.remove('checked');
    this.innerHTML = checkboxIcon;
  } else {
    this.classList.add('checked');
    this.innerHTML = checkedCheckboxIcon;
  }
}

function saveBtnInit() {
    let saveBtn = document.querySelector('#saveBtn');
    saveBtn.onclick = function () {
        let idsToSaveAsString = '';
        for (let entry of entries) {
            if (!entry.classList.contains('deleted') &&
                entry.querySelector('.checkbox').classList.contains('checked')) {
                let index = entry.id.match(/(\d+)/)[0]; //get number from string
                idsToSaveAsString += '' + data[index][0] + ','; 
                hideEntry(entry);
           }
        }
        idsToSaveAsString = idsToSaveAsString.slice(0,-1);
        jQuery.ajax({
            url:     "php/accept-marks-ajax.php",
            type:     "POST",
            dataType: "html",
            data: 'yes=' + idsToSaveAsString,
            success: function(response) {
                if (response == -1) { alert('Не удалось подключится к базе данных.'); }
                else if (response == -2) { alert('Произошла ошибка при выполнении запроса.'); }
                else if (response == 1) { alert("Метки успешно перенесены в постоянные."); }
                else { alert("От сервера получен некорректный ответ - результат неизвестен."); }
        	},
        	error: function(response) { alert('Произошла ошибка при выполнении AJAX.'); }
     	});
     	if (entriesLeft == 0) {
 	        disableSaveBtn();
            disableDeleteBtn();
    	}
    }
}

function disableSaveBtn() {
    let saveBtn = document.querySelector('#saveBtn');
    saveBtn.setAttribute("disabled", "disabled");
    saveBtn.style.cursor = 'default';
}

function deleteBtnInit() {
  let deleteBtn = document.querySelector('#deleteBtn');
  deleteBtn.onclick = function () {
    let idsToDeleteAsString = '';  
    for (let entry of entries) {
      if (!entry.classList.contains('deleted') &&
        entry.querySelector('.checkbox').classList.contains('checked')) {
        let index = entry.id.match(/(\d+)/)[0]; //get number from string
        idsToDeleteAsString += '' + data[index][0] + ','; 
        hideEntry(entry);
      }
    }
    idsToDeleteAsString = idsToDeleteAsString.slice(0,-1);
    jQuery.ajax({
        url:     "php/delete-unaccepted-marks-ajax.php",
        type:     "POST",
        dataType: "html",
        data: 'no=' + idsToDeleteAsString,
        success: function(response) {
            if (response == -1) { alert('Не удалось подключится к базе данных.'); }
            else if (response == -2) { alert('Произошла ошибка при выполнении запроса.'); }
            else if (response == 1) { alert("Метки успешно удалены."); }
            else { alert("От сервера получен некорректный ответ - результат неизвестен."); }
    	},
    	error: function(response) { alert('Произошла ошибка при выполнении AJAX.'); }
 	});
 	if (entriesLeft == 0) {
 	    disableSaveBtn();
        disableDeleteBtn();
 	}
  };
}

function disableDeleteBtn() {
    let deleteBtn = document.querySelector('#deleteBtn');
    deleteBtn.setAttribute("disabled", "disabled");
    deleteBtn.style.cursor = 'default';
}

function hideEntry(entry) {
  entry.classList.add('deleted');
  entriesLeft--;
}

function handleAuthForm() {
    jQuery.ajax({
        url:     "php/master-ajax.php",
        type:     "POST",
        dataType: "html",
        data: jQuery("#authForm").serialize(),
        success: function(response) {
            if (response == 1) {
                  hideAuthForm();
                  handleData();
            }
            else if (response == -1) { alert('Не удалось подключится к базе данных.'); }
            else if (response == -2) { alert('Произошла ошибка при выполнении запроса.'); }
            else if (response == 0) { alert("Неверный пароль."); }
            else { alert("От сервера получен некорректный ответ - результат неизвестен."); }
    	},
    	error: function(response) { alert('Произошла ошибка при выполнении AJAX.'); }
 	});
}

function hideAuthForm() {
  document.querySelector('#authForm').classList.add('hidden');
}