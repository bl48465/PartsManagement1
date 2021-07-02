import "./widgetSm.css";
import { Visibility } from "@material-ui/icons";

export default function WidgetSm() {
  return (
    <div className="widgetSm">
      <span className="widgetSmTitle">New Join Members</span>
      <ul className="widgetSmList">
        <li className="widgetSmListItem">
          <img
            src="data:image/png;base64,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"
            alt=""
            className="widgetSmImg"
          />
          <div className="widgetSmUser">
            <span className="widgetSmUsername">Dren baba</span>
            <span className="widgetSmUserTitle">Software Engineer</span>
          </div>
          <button className="widgetSmButton">
            <Visibility className="widgetSmIcon" />
            Display
          </button>
        </li>
        <li className="widgetSmListItem">
          <img
            src="data:image/png;base64,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"
            alt=""
            className="widgetSmImg"
          />
          <div className="widgetSmUser">
            <span className="widgetSmUsername">Dren baba</span>
            <span className="widgetSmUserTitle">Software Engineer</span>
          </div>
          <button className="widgetSmButton">
            <Visibility className="widgetSmIcon" />
            Display
          </button>
        </li>
        <li className="widgetSmListItem">
          <img
            src="data:image/png;base64,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"
            alt=""
            className="widgetSmImg"
          />
          <div className="widgetSmUser">
            <span className="widgetSmUsername">Dren baba</span>
            <span className="widgetSmUserTitle">Software Engineer</span>
          </div>
          <button className="widgetSmButton">
            <Visibility className="widgetSmIcon" />
            Display
          </button>
        </li>
        <li className="widgetSmListItem">
          <img
            src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAYFBMVEX///9kZGRvb29YWFhdXV1hYWFbW1tWVlb39/fOzs5TU1Nqamro6OikpKTv7+/29vZ1dXV8fHzc3NyamprW1tbi4uKrq6u+vr6FhYW0tLTDw8OUlJSLi4vKysrS0tJoaGhGFGv0AAAGmUlEQVR4nO2da5uqOgyFhbaAKIgiIF7//788MM6cLXgDumIz8+T9vt1d00vSJA2zmSAIgiAIgiAIgiAIgiAIgiAIQo8oLbbz0/403xZp5HowaFbzcrfQoVJBi1Kh9o/l+c/ILMosDrQx3i3GaBWv66XrwdkTVb7SXXE3MrVan1yP0I40V8Ezed8iA5OsXA9zMlGi9Et5V3RQuh7pRGo9RF9L4O1dD3YChR8M1Nei1qnrAY+lUq/3Xx+j566HPI6jGqWvJU5cD3oEq2zoDrwl2Lke92CWZtwK/UH7v8RuFG9M4HOM9yvOm2LkGdORaH6BxOX4M6Yjkf1CXXnTZ/BLou9awTt8O4HNcbN2LeE1hylmokvA2i5WobXAxvSfXct4jt0p8z+a72mT2W7CK+boWsgzKswUel7I1Atf2Z8y35iLay2PyWEKvaB2LeYRKeIc/UG7VvOIBDeFPCcxQgr0zMK1nnuqMWGZ9yh+Zt/aIe3CzyYukedMS+xaUZ8aug0bAm7h/jV2kTbL9OBaUpcVymH7BzO/ZotXGPLKvJXobchuIx7R27Bx3HhlpC5wgdwsIn4bMnPcUgKFXuBa1S0FhULFKVxDYCwahZwi/HPsxeJbISeDSKOwcC3rBhqFG9eybjj/+TmkOWk47UMaa8FJIShh0VPIyR4SXA+Z+TQzgpOGl1+Kyjp1FPK6W+R//n5YEdzxeaXYNgRxGk6OdwN8lbIrO9mhJerctaQee7S9UFvXknqsYrRC14ruAC9Tdou0uSJiT9OQ09XpmwtyEg3H6jZoEphhCrgB6NawM4ZXgJPIcwpnswVqJxquVftbVC6fWerwBkD9bAvjl17RxIcWXUzmWscLIOuUVb7ijtreswl5ZbfvONpuRcW6kL3FMialmZXRPMKqwI37a4svVhaGX3M+Rv8RTZ7FXzGDLdGkB5a/6onllEeyjZngd61/QR2OXakmrFwPehwbb9xKDXy23na0qZJjtmgMWW+I+YhpNGHP2S4aJ36RHZPKdS5/Wa+1avuWmHaUvX208Qe+lzVq/eiv0/yqDpR22QClyuJO2xLd7xqwXwzQaFTW+2fzTrsJo+PMzRYtzf2bbXXsddXZv5tHHfb1RfcHcfM/ff7KuH/c1sME/R4em9w8a1BjtLok/bho9fituzafbQ6Srp8avAc9PLbJQqluk6G2xZDyy7tzZNwP03F61VPAqAdvltJzfchMHKqWMPbWeb19UGpRv1rT5nM50/LNTV5lz0Ly6bLl2VwU2Zt4ZN+mUJG8dckawzG+j1c0wIB+5nr8XqDXdkaqx2lc1cEQJ+gTEuuBwSYdJMNPhjQZpK8hJH+YOB8eTdPxcVged7uLhzux1K+gx5WsG7W4s3d9NsllXDMU4mDj2DiT0eEl2T7bktG2kfe0X92znySNdCRT0ku68Z7Lc/8vvzyXjdc+qdsS4WlTTC1HaDyYUPu7PCnrqi6TfOeH7ZVk4q/FdJcNu1hoexu6YuzyG3Qp8D1FFekUFJUXjq8/nIqhEVhTFORPg6ghAb7AcjokkwhuKWBHQBHX4LMLv8ALPHE5SK8ofB4V/uDeDrxNhHeFsAXu2BA8R7cDXsoPq3dCgX5wQvJ0yw7w4z12ixS+TAle/diCvQmn6Dp1BDEynAF/a4AA2hrkwG+RNssUmfdnZytakKXSJG0v7AHGFU8ctyG0GhzaMBAH0CLCH6ZhABa889yGwNfe0L6dSGDPTEl6QiCAvVGEdwxEoVHxKJYeTQvskSKzEM0/YIcpQTM2DKh7PklbDwwB5tNtDCMYP4CegJ35KgSZC1YJiy53dYLTYBiF+kFjsmxMbxYtGlO0wNbgw5oNM707tYD6EDGMlf4AcmrYujSwHBvfKUTFvfmaQ1RAkbFCD+N6c1YIadwe8XVLQXU1jC9PoO/RiEKnQCKmf1/h3z9pOFsLUCiK7/UQ5ZeCv3OEBHQ/JPg6BwpQBpFxnAYUiWKa424B9R5kmz7ElXuzPWpg7aLZhhNB23A2K7gu0xiTmJkxLYmC9jRnmrkIgW1BXGt5CLRcn82rtVtiaBk0w7g3uJcyySc6rIB/93nPrQ4au0ZbBrVS+BwU/SNzThJjkq5D71qafBAagY3hH92EjQYTkLWKLhYcnBvaZkPluB4WBGiSB7I3LA8j+pDAMTpM6L9zlZZmUjsLhLzFyL4+k9kmXnxttfcpdKBiv/zoFyGiTVUedpn/CbJdXu4Zfu9CEARBEARBEARBEARBEARBED7Lf5/edPnfYfjDAAAAAElFTkSuQmCC"
            alt=""
            className="widgetSmImg"
          />
          <div className="widgetSmUser">
            <span className="widgetSmUsername">Dren baba</span>
            <span className="widgetSmUserTitle">Software Engineer</span>
          </div>
          <button className="widgetSmButton">
            <Visibility className="widgetSmIcon" />
            Display
          </button>
        </li>
        <li className="widgetSmListItem">
          <img
            src="data:image/png;base64,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"
            alt=""
            className="widgetSmImg"
          />
          <div className="widgetSmUser">
            <span className="widgetSmUsername">Dren baba</span>
            <span className="widgetSmUserTitle">Software Engineer</span>
          </div>
          <button className="widgetSmButton">
            <Visibility className="widgetSmIcon" />
            Display
          </button>
        </li>
      </ul>
    </div>
  );
}
