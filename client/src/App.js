import React, {useEffect, useState} from "react";

import Loader from "./Components/Loader";
import Table from "./Components/Table";

import {getByCompanyBinarySign} from "./services/companyBranchesService";

function App() {
    const [loading, setLoading] = useState(true);
    const [companyBranches, setCompanyBranches] = useState([]);

    useEffect(() => {
        getByCompanyBinarySign()
            .then((result) => {
                if (!result.success) {
                    throw Error(result.error);
                }

                setCompanyBranches(result.companyBranches);
                setLoading(false);
            })
            .catch((error) => {
                alert(error);
            });
    }, []);

    return (
        <>
            {
                loading &&
                <Loader/>
            }
            {
                !loading &&
                <Table headers={getTableHeaders()} data={companyBranches}/>
            }
        </>
    );
}

function getTableHeaders() {
    return ["Филиал", "Компания Филиала", "Группа Компании", "Связанные филиалы"];
}

export default App;
