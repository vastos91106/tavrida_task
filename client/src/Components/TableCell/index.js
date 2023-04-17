import React from "react";
import {css} from "aphrodite";

import style from "./style";

function TableCell({cell}) {
    const rows = Object.keys(cell).map((key) => {
        const value = cell[key];

        let result =  value.toString();
        return <td className={css(style.td)}>{result}</td>;
    });

    return (
        <tr>
            {
                rows
            }
        </tr>
    )
}

export default React.memo(TableCell);