const check = document.querySelectorAll('.checkbox-delete');
const saveBtn = document.querySelector('#saveChanges');
const editForm = document.querySelector('#edit-form');
let ids = [];

editForm.addEventListener('submit', (e) => {
  
    fetch("/Bands/Korv",
        {
            
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "POST",

            body: JSON.stringify(ids)
        })
        .then(function (res) { console.log(res) })
        .catch(function (res) { console.log(res) })
});

for (var i = 0; i < check.length; i++) {
    check[i].addEventListener('click', (e) => {
        ids.push({ 'id': e.target.value });
        console.log(e.target.value);
    });
}

