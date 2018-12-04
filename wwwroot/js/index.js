document.addEventListener('DOMContentLoaded', () => {
    start();
});
let userName = 'kewl';
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/forumhub")
    .build();

connection.on("ReceivePost", renderPost);


startConnection();


function startConnection() {
    connection.start()
        .then(onConnected)
        .catch(err => console.log('err'));

};

function start() {
    const nameInput = document.querySelector('#name-input');
    const postContent = document.querySelector('#post-content');
    const chatForm = document.querySelector('#chat-form');


    chatForm.addEventListener('submit', (e) => {
        e.preventDefault();
        const post = postContent.value;
        userName = nameInput.value;
        console.log(userName);

        postContent.value = '';
        console.log(post);
        postMessage(post);
    });

};

function postMessage(text) {
    if (text && text.length) {
        connection.invoke('PostMessage', userName, text);
    }
};

function renderPost(name, time, message) {
    console.log(`${name} ${time} ${message}`);
    const chatContainer = document.querySelector('#chat-box');
    const p = document.createElement("p");
    const text = document.createTextNode(`${name} - ${message}`);
    p.appendChild(text);
    chatContainer.appendChild(p);

   
};

function onConnected() {
    console.log("connected");
};

