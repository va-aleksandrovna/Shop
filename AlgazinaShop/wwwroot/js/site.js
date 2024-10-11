// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToCart(event, id) {
    document.getElementById(id).setAttribute('disabled', 'true'); // Делаем кнопку неактивной
    document.getElementById(id).style.backgroundColor = '#ccc'; // Меняем цвет кнопки на серый
    document.getElementById(id).innerText = 'Товар добавлен'; // Меняем текст кнопки на "Товар добавлен"
    // Store the added item state in session
    sessionStorage.setItem('item_' + id, 'added');
}

window.onload = function () {
    var buttons = document.getElementsByClassName('btn');
    for (var i = 0; i < buttons.length; i++) {
        var itemId = buttons[i].id;
        if (sessionStorage.getItem('item_' + itemId) === 'added') {
            buttons[i].setAttribute('disabled', 'true');
            buttons[i].style.backgroundColor = '#ccc';
            buttons[i].innerText = 'Товар добавлен';
        }
    }
}

function deleteToCart(event, id) {
    sessionStorage.removeItem('item_' + id);
    document.getElementById('hidden_iframe').onload = function () {
        window.location.reload(); // Reload the page after the form submission is completed
    };
}

function deleteAllToCart(event) {
    sessionStorage.clear();
    document.getElementById('hidden_iframe').onload = function () {
        window.location.reload(); // Reload the page after the form submission is completed
    };
}

let inputPhone = document.getElementById("inputPhone");
inputPhone.oninput = () => phoneMask(inputPhone)
function phoneMask(inputEl) {
    let patStringArr = "+7 (___) ___-__-__".split('');
    let arrPush = [4, 5, 6, 9, 10, 11, 13, 14, 16, 17]
    let val = inputEl.value;
    let arr = val.replace(/\D+/g, "").split('').splice(1);
    let n;
    let ni;
    arr.forEach((s, i) => {
        n = arrPush[i];
        patStringArr[n] = s
        ni = i
    });
    arr.length < 10 ? inputEl.style.color = 'red' : inputEl.style.color = 'green';
    inputEl.value = patStringArr.join('');
    n ? inputEl.setSelectionRange(n + 1, n + 1) : inputEl.setSelectionRange(19, 19)
}

function Modal(event) {
    // Находим кнопку
    var btn = document.getElementById("btn-fil");
    // Находим модальное окно
    var modal = document.getElementById("myModal");
    // Находим элемент для закрытия модального окна
    var closeBtn = document.getElementsByClassName("btn-close")[0];

    modal.style.display = "block"; // Показываем модальное окно

    // Добавляем обработчик события на нажатие элемента для закрытия модального окна
    closeBtn.onclick = function () {
        modal.style.display = "none"; // Скрываем модальное окно
    }
}