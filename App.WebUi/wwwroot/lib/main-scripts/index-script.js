async function getCompanies() {
    const response = await fetch("/api/companies", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const companies = await response.json();
    const rows = document.getElementById("companies");
    companies.forEach(company => rows.append(row(company)));
}

function row(company) {
    const div = document.createElement("div");
    div.setAttribute("data-rowid", company.id);

    const nameTd = document.createElement("a");
    nameTd.setAttribute("onClick", `getDetails(${company.id})`);
    nameTd.append(company.name);
    div.append(nameTd);

    const cityTd = document.createElement("div");
    cityTd.append(company.city);
    div.append(cityTd);

    const stateTd = document.createElement("div");
    stateTd.append(company.state);
    div.append(stateTd);

    const phoneTd = document.createElement("div");
    phoneTd.append(company.phone);
    div.append(phoneTd);

    return div;
}
