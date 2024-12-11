const offScreenMenu = document.querySelector('.off-screen-menu');
const menuList = document.querySelector('.menu-items');
const menuItems = document.querySelectorAll('.menu-item');
offScreenMenu.addEventListener('click', () => {
    menuList.classList.toggle('active');
    menuItems.forEach(item => item.classList.toggle('active'));
})
