import React from "react";
import {css} from "aphrodite";

import style from "./style";

function TableHeader({headers}) {
    const rows = headers.map((name) => {
        return (
            <th>{name}</th>
        )
    });

    return (
        <tr className={css(style.th)}>
            {
                rows
            }
        </tr>
    )
}

export default React.memo(TableHeader);