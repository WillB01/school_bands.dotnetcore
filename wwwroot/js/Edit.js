const check = document.querySelectorAll('.checkbox-delete');
const saveBtn = document.querySelector('#saveChanges');
const editForm = document.querySelector('#edit-form');
let albumIdsAndBandIds = [];


editForm.addEventListener('submit', (e) => {
    console.log(albumIdsAndBandIds);
    fetch("/Bands/Korv",
        {
            
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "POST",

            body: JSON.stringify(albumIdsAndBandIds)
        })
        .then(function (res) { console.log(res) })
        .catch(function (res) { console.log(res) })
});




for (var i = 0; i < check.length; i++) {
    check[i].checked = false;

    check[i].addEventListener('change', function (e) {
        const divClass = document.querySelector(`div[data-key="${e.target.value.split(',')[0]}"]`);
        if (this.checked) {
            albumIdsAndBandIds.push({ 'AlbumId': e.target.value.split(',')[0], 'BandId': e.target.value.split(',')[1] });
           
            divClass.classList.add("hideAlbums");

        }
        if (!this.checked) {
            divClass.classList.remove("hideAlbums");
            albumIdsAndBandIds = albumIdsAndBandIds.filter(item => {
                return item.AlbumId !== e.target.value.split(',')[0];
            });
        }
        console.log(albumIdsAndBandIds);
    });
}

