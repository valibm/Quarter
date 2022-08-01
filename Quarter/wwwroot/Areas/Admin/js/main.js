//const formCreate = document.getElementById("formCreate");
//const floorPlanForm = document.getElementById("floorPlanForm");
//let FloorPlans = [];

//formCreate.addEventListener('submit', async (e) => {
//    e.preventDefault();
//    let formData = new FormData(e.target);
//    let data = Object.fromEntries(formData);
//    data.FloorPlans = FloorPlans;
//    console.log(data);
//    var productData = { productVM:  data  };
//    console.log(productData);
//    let fetchData = await fetch("/Admin/Product/Create", {
//        method: 'POST',
//        headers: {
//            'Accept': 'application/json',
//            "Content-type": "application/json"
//        },
//        body: JSON.stringify(productData.productVM)
//    });
//    console.log(fetchData);
//})

//floorPlanForm.addEventListener('submit', async (e) => {
//    e.preventDefault();
//    let formData = new FormData(e.target);
//    let data = Object.fromEntries(formData);
//    console.log(data);
//    FloorPlans.push(data);
//    //let fetchData = await fetch("/Admin/Product/AddFloorPlan", {
//    //    method: 'POST',
//    //    body: formData
//    //});
//})