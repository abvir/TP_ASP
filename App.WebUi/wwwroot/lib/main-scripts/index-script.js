let currentCompanyId = 0;

async function getCompanies() {
    const response = await fetch("/api/companies", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const companies = await response.json();
    const rows = document.getElementById("company-rows");
    companies.forEach(company => rows.append(rowCompany(company)));
    
}

async function getDetails(companyId) {
    currentCompanyId = companyId;
    await getCurrentCompanyInfo();
    await getCurrentCompanyHistory();
    await getCurrentCompanyNotes();
    await getCurrentCompanyEmployees();
}

async function getCurrentCompanyEmployees() {
    const response = await fetch(`/api/company-employees/${currentCompanyId}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const companyEmployees = await response.json();
    const rows = document.getElementById("employee-rows");
    rows.innerHTML = "";
    companyEmployees.forEach(employee => rows.append(rowEmployee(employee)));
}

async function getCurrentCompanyNotes() {
    const response = await fetch(`/api/company-notes/${currentCompanyId}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const companyNotes = await response.json();
    const rows = document.getElementById("company-note-rows");
    rows.innerHTML = "";
    companyNotes.forEach(note => rows.append(rowNote(note)));
}

async function getCurrentCompanyHistory() {
    const response = await fetch(`/api/company-order-history/${currentCompanyId}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const companyHistory = await response.json();
    const rows = document.getElementById("company-history-rows");
    rows.innerHTML = "";
    companyHistory.forEach(order => rows.append(rowOrder(order)));
}

async function getCurrentCompanyInfo() {
    const response = await fetch(`/api/company-detail/${currentCompanyId}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const companyDetail = await response.json();
    document.getElementById("company-detail-name").innerText = companyDetail.name;
    document.getElementById("company-info-id").value = companyDetail.id;
    document.getElementById("company-info-name").value = companyDetail.name;
    document.getElementById("company-info-address").value = companyDetail.address;
    document.getElementById("company-info-city").value = companyDetail.city;
    document.getElementById("company-info-state").value = companyDetail.state;
}

async function getEmployeeDetails(employeeId) {

    const response = await fetch(`/api/employee-detail/${employeeId}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const employeeDetail = await response.json();
    document.getElementById("employee-detail-firstName").value = employeeDetail.firstName;
    document.getElementById("employee-detail-lastName").value = employeeDetail.lastName;
    document.getElementById("employee-detail-title").value = employeeDetail.title;
    document.getElementById("employee-detail-date").value = employeeDetail.date;
    document.getElementById("employee-detail-position").value = employeeDetail.position;
}


function rowCompany(company) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", company.id);

    const tdName = document.createElement("td");
    const aName = document.createElement("a");
    aName.setAttribute("onClick", `getDetails(${company.id})`);
    aName.append(company.name);
    tdName.append(aName);
    tr.append(tdName);

    const tdCity = document.createElement("td");
    tdCity.append(company.city);
    tr.append(tdCity);

    const tdState = document.createElement("td");
    tdState.append(company.state);
    tr.append(tdState);

    const tdPhone = document.createElement("td");
    tdPhone.append(company.phone);
    tr.append(tdPhone);

    return tr;
}

function rowEmployee(employee) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", employee.id);

    const tdFirstName = document.createElement("td");
    const aFirstName = document.createElement("a");
    aFirstName.setAttribute("onClick", `getEmployeeDetails(${employee.id})`);
    aFirstName.append(employee.firstName);
    tdFirstName.append(aFirstName);
    tr.append(tdFirstName);

    const tdLastName = document.createElement("td");
    const aLastName = document.createElement("a");
    aLastName.setAttribute("onClick", `getEmployeeDetails(${employee.id})`);
    aLastName.append(employee.lastName);
    tdLastName.append(aLastName);
    tr.append(tdLastName);
    return tr;
}

function rowNote(note) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", note.id);

    const tdNumber = document.createElement("td");
    tdNumber.append(note.number);
    tr.append(tdNumber);

    const tdEmployee = document.createElement("td");
    tdEmployee.append(note.employee);
    tr.append(tdEmployee);

    return tr;
}

function rowOrder(order) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", order.id);

    const tdDate = document.createElement("td");
    tdDate.append(order.date);
    tr.append(tdDate);

    const tdCity = document.createElement("td");
    tdCity.append(order.city);
    tr.append(tdCity);

    return tr;
}

getCompanies();