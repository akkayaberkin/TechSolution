const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container1');

if (signUpButton != null) {
	signUpButton.addEventListener('click', () => {
		window.location = '/Home/Register';

		//	container.classList.add("right-panel-active");
	});
}

if (signInButton != null) {
	signInButton.addEventListener('click', () => {
		window.location = '/Home/Login';
	});
}
