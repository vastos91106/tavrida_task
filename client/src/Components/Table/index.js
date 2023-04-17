import React from "react";
import {css} from "aphrodite";

import TableCell from "../TableCell";
import TableHeader from "../TableHeader";

import style from "./style";

function Table({data, headers}) {
    return (
        <table className={css(style.table)}>
            <TableHeader headers={headers}/>
            {
                data.map(cell => <TableCell cell={cell}/>)
            }
        </table>
    )
}

export default React.memo(Table);