export default function CreateTable(Dataset = [], Table, TableFunction) {
    const thead = Table.querySelector("thead");
    const tbody = Table.querySelector("tbody");
    thead.innerHTML = "";
    tbody.innerHTML = "";
    Dataset.forEach((item, index) => {
        const row = document.createElement("tr");
        for (var prop in item) {
            if (index == 0) {
                const th = document.createElement("th");
                th.innerText = prop;
                thead.append(th);
            }
            const td = document.createElement("td");
            td.innerText = item[prop];
            row.append(td);
        }
        if (index == 0) {
            const th = document.createElement("th");
            th.innerText = "Action";
            thead.append(th);
        }
        const tdAction = document.createElement("td");
        const btn = document.createElement("input");
        btn.type = "button";
        btn.className = "BTN BTNOK";
        btn.value = "Edit";
        btn.onclick = () => {
            //console.log(item);
            TableFunction(item);
        }
        tdAction.append(btn);
        row.append(tdAction);
        tbody.append(row);
    });
}