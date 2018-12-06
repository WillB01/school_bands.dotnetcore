// delete albums stuff

const saveBtn = document.querySelector('#saveChanges');
const editForm = document.querySelector('#edit-form');
//add album stuff
const createAlbumBtn = document.querySelector('#create-album-btn');
const albumTitle = document.querySelector('#add-album-title');
const albumYear = document.querySelector('#add-album-year');
const albumBandId = document.querySelector('#add-album-bandId');
const editMainAlbumsContainer = document.querySelector('#edit-album-container-main');
let albumIdsAndBandIds = [];
let newAlbum = []
let newAlbumsRemoveContainer = [];


editForm.addEventListener('submit', (e) => {
    
    fetch("/Bands/Korv",
        {

            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "POST",

            body: JSON.stringify({ newAlbum, albumIdsAndBandIds })
        })
        .then(function (res) { console.log(res);})
        .catch (function (res) { console.log(res); });
});


const startCheckboxes = () => {
    const check = document.querySelectorAll('.checkbox-delete');
    console.log(newAlbumsRemoveContainer);


    for (var i = 0; i < check.length; i++) {
        console.log(check[i].checked);
      

        check[i].addEventListener('change', function (e) {
  
            const firstItemInBoxValue = e.target.value.split(',')[0];
            const divClass = document.querySelector(`div[data-key="${e.target.value.split(',')[0]}"]`);
          
            if (this.checked) {
                albumIdsAndBandIds.push({ 'AlbumId': e.target.value.split(',')[0], 'BandId': e.target.value.split(',')[1] });
                divClass.classList.add("hideAlbums");

               
                newAlbum = newAlbumFilter(e);

                
            }
            if (!this.checked) {
                divClass.classList.remove("hideAlbums");
                albumIdsAndBandIds = albumIdsAndBandIds.filter(item => {
                    return item.AlbumId !== e.target.value.split(',')[0]; //DO TO FIX FILTERED FOR NOT IN DATABASE
                });

                newAlbumsRemoveContainer.forEach((item) => {
                    if (item.fakeId.toString() === e.target.value.split(',')[0]) {
                        newAlbum.push(item);
                        newAlbum = removeDuplicates(newAlbum);
                    };

               
                });
                console.log(newAlbum);
            }
          
        });
    }

    newAlbum = removeDuplicates(newAlbum);
    newAlbumsRemoveContainer = removeDuplicates(newAlbumsRemoveContainer);

 

};

startCheckboxes();

function newAlbumFilter(e) {
    return newAlbum.filter(item => {
        if (item.fakeId.toString() === e.target.value.split(',')[0]) {
            newAlbumsRemoveContainer.push(item);
        }
        return item.fakeId.toString() !== e.target.value.split(',')[0];
    });
};

function removeDuplicates(myObject) {
    return myObject.filter((item, index, self) => {
        
        return index === self.findIndex((t) => (
            t.Title === item.Title 
        ))
    }
       
        
)};

//////////////////////////////////////////////////

let counter = 0;
createAlbumBtn.addEventListener('click', (e) => {
    e.preventDefault();
    counter += 1;

    const title = albumTitle.value;
    const year = albumYear.value;
    const bandId = albumBandId.value;


    newAlbum.push({
        'Title': title,
        'Year': year,
        'BandId': bandId,
        'fakeId': counter
    });


    
    albumTitle.value = '';
    albumYear.value = '';



    const myDiv = document.createElement('div');
    myDiv.className += 'edit-albums-container';

    
    myDiv.innerHTML =
        ` <div data-key=${counter} id=${counter} class=${counter}>
                <label>Album Title</label>
                <input value="${title}" name="albumTitle" />
                <input type="hidden" name="albumIds" value="@item.Id" />
                <label>Album Year</label>
                <input value="${year}" name="albumYear" />
            </div>
          
            <div>
                <label>Delete</label>
                <input class="checkbox-delete" type="checkbox" value=${counter},${bandId}" />
            </div>
           `;
    

    editMainAlbumsContainer.appendChild(myDiv);

    startCheckboxes();

});

