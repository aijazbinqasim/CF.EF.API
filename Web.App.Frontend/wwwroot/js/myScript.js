function showName() {

    let result = confirm("Are you sure you want to show your name?");

    if (result) {
        let name = prompt("Please enter your name:");
        alert(`Name is: ${name}`);
    }
    return;
}
