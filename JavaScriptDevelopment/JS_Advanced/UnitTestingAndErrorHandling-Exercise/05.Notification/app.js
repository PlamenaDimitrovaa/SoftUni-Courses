function notify(message) {
  let notificationDivElement = document.getElementById('notification');
  notificationDivElement.textContent = message;
  notificationDivElement.style.display = 'block';
  notificationDivElement.addEventListener('click', (e) => {
    e.target.style.display = 'none';
  });
}