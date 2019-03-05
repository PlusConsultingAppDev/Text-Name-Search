document.getElementById('add-button').addEventListener('click', addUsers);

/**
 * If all fields are entered, the employee is added to the list.
 */
function addUsers() {
  var firstName = document.getElementById('firstname').value.replace(/\s/g, '');
  var middleName = document.getElementById('middlename').value.replace(/\s/g, '');
  var lastName = document.getElementById('lastname').value.replace(/\s/g, '');
  var fullName = firstName + " " + middleName + " " + lastName;

  var validInput = checkValidInput(firstName, middleName, lastName);

  if (!validInput) {
    document.getElementById('error').style.display = 'block';
    return;
  }
  document.getElementById('error').style.display = 'none';

  createListItem(fullName);
  resetFields();

  document.getElementById('firstname').focus();
}

function createListItem(fullName) {
  var listItem = document.createElement('li');
  var text = document.createTextNode(fullName);
  listItem.appendChild(text);
  listItem.className = 'item';

  var span = document.createElement('span');
  var txt = document.createTextNode("\u00D7");
  span.className = 'remove';
  span.appendChild(txt);
  span.addEventListener('click', function () {
    var li = this.parentElement;
    var ul = li.parentElement;
    ul.removeChild(li);
  });
  listItem.appendChild(span);

  document.getElementById('list').appendChild(listItem);
}

function checkValidInput(firstName, middleName, lastName) {
  var valid = true;
  if (firstName.length === 0 || !firstName.trim()) {
    valid = false;
  } else if (middleName.length === 0 || !middleName.trim()) {
    valid = false;
  } else if (lastName.length === 0 || !lastName.trim()) {
    valid = false;
  }

  return valid;
}

function resetFields() {
  document.getElementById('firstname').value = "";
  document.getElementById('middlename').value = "";
  document.getElementById('lastname').value = ""; 
}

/**
 * Send an array of all employees to the server with AJAX.
 */
function sendEmployees() {
  var employees = [];
  var listItems = document.getElementsByClassName('item');
  for (var i = 0; i < listItems.length; i++) {
    // Removes the span 'x'
    employees.push(listItems[i].textContent.slice(0, -1)); 
    console.log(employees[i]);
  }

  var xhr = new XMLHttpRequest();
  xhr.open('POST', "Default.aspx/UpdateEmployees", true);
  xhr.setRequestHeader("Content-Type", "application/json");

  xhr.onload = function () {
    if (xhr.readyState != 4 || xhr.status != 200) {
      console.log("Error: Could not POST to server.");
      return;
    }
  }

  xhr.send(JSON.stringify({ employees: employees }));
}

/**
 * Submit form on enter. 
 */
document.getElementById('firstname').onkeypress = function (e) {
  if (e.keyCode == 13) {
    document.getElementById('add-button').click();
  }
}
document.getElementById('middlename').onkeypress = function (e) {
  if (e.keyCode == 13) {
    document.getElementById('add-button').click();
  }
}
document.getElementById('lastname').onkeypress = function (e) {
  if (e.keyCode == 13) {
    document.getElementById('add-button').click();
  }
}