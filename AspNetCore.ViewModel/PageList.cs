using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.ViewModel
{
    /// <summary>
    /// 分页获取数据
    /// </summary>
    /// <typeparam name="T">列表数据项</typeparam>
    /// <typeparam name="TObj">其他附加数据</typeparam>
    public class PageList<T, TObj> : IList<T> where T : class
    {
        /// <summary>
        /// 每页展示数量
        /// </summary>
   
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页的索引
        /// </summary>

        public int PageIndex { get; set; }

        /// <summary>
        /// 扩展对象
        /// </summary>
   
        public TObj Obj { get; set; }

        /// <summary>
        /// 用于小计
        /// </summary>
   
        public T SubTotal { get; set; }

        #region 计算页码

        /// <summary>
        /// 总页数
        /// </summary>
      
        public int TotalPageNum
        {
            get
            {
                if (RecordTotal <= 0 || RecordTotal <= PageSize)
                {
                    return 1;
                }
                return (RecordTotal % PageSize == 0) ? RecordTotal / PageSize : RecordTotal / PageSize + 1;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
     
        public int RecordTotal { get; set; }

        #endregion

        private IList<T> _list { get; set; }

        /// <summary>
        /// 集合
        /// </summary>
    
        public IList<T> List
        {
            get
            {
                return _list ?? new List<T>();
            }
            set { _list = value; }
        }

        public PageList()
        {
            _list = new List<T>();
            PageSize = 10;
            RecordTotal = 0;
        }

        public PageList(int pageIndex, int pageSize)
        {
            _list = new List<T>();
            PageSize = pageSize;
            PageIndex = pageIndex;
            RecordTotal = 0;
        }

        public PageList(IList<T> list, int recordTotal)
        {
            _list = list;
            RecordTotal = recordTotal;
        }

        public int IndexOf(T item)
        {
            if (List != null)
            {
                return List.IndexOf(item);
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (List != null)
            {
                List.Insert(index, item);
            }
        }

        public void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return List[index];
            }
            set { List[index] = value; }
        }

        public void Add(T item)
        {
            List.Add(item);
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(T item)
        {
            return List.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return List.Count; }
        }

        public bool IsReadOnly
        {
            get { return List.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return List.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        
    }

    public class PageList<T> : PageList<T, object> where T : class
    {
        public PageList(int pageIndex, int pageSize) : base(pageIndex, pageSize)
        {

        }

        public PageList(IList<T> list, int recordTotal) : base(list, recordTotal)
        {

        }

        public PageList()
        {

        }
    }
}
